using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Approval;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.AppService.Exceptions;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Loans;
using SiKoperasi.ExternalService.Contract;
using static SiKoperasi.AppService.Util.Constant;

namespace SiKoperasi.AppService.Services.Loans
{
    public class LoanService : BaseCrudService<Loan, LoanCreateDto, LoanEditDto, LoanDto, AppDbContext>, ILoanService
    {
        private readonly IMasterSequenceService masterSequenceService;
        private readonly IInstalmentService instalmentService;
        private readonly IGoogleDriveService googleDriveService;
        private readonly IRefService refService;
        private readonly IApprovalService approvalService;

        private const string LOAN_BASE_FOLDER = "LOAN";
        public LoanService(AppDbContext dbContext, IMapper mapper, IMasterSequenceService masterSequenceService, IInstalmentService instalmentService, IGoogleDriveService googleDriveService, IRefService refService, IApprovalService approvalService) 
            : base(dbContext, mapper)
        {
            this.masterSequenceService = masterSequenceService;
            this.instalmentService = instalmentService;
            this.refService = refService;
            this.googleDriveService = googleDriveService;
            this.approvalService = approvalService;
        }

        public async Task<LoanDto> GetLoanAsync(string id)
        {
            return await BaseGetByIdAsync(id, true);
        }

        public async Task<PagingModel<LoanDto>> GetLoanPagingAsync(QueryParamDto queryParam)
        {
            return await BaseGetPagingDataDtoAsync(queryParam);
        }

        public async Task<LoanDto> CreateLoanAsync(LoanCreateDto payload)
        {
            return await BaseCreateAsync(payload);
        }

        public async Task SubmitFinalLoanAsync(string id, string currUser)
        {
            Loan loan = await BaseGetModelByIdAsync(id);
            List<string> loanDocMandatoryId = dbContext.RefLoanDocuments.Where(a => a.IsActive && a.IsMandatory).Select(a => a.Id).ToList();
            if (!await dbContext.LoanDocuments.AnyAsync(a => a.LoanId == id && loanDocMandatoryId.Contains(a.RefLoanDocumentId)))
                throw new Exception("Please Complete Mandatory Loan Document");

            string schemecode = dbContext.LoanSchemes.Where(a => a.Id == loan.LoanSchemeId).Select(a => a.ApprovalSchemeCode).Single();
            loan.Status = LOAN_STATUS_REQ;
            dbContext.Loans.Update(loan);
            //await dbContext.SaveChangesAsync();

            ApprovalReqDto approvalReq = new(schemecode, loan.LoanNo, null, currUser);
            await approvalService.CreateNewApvRequestAsync(approvalReq);
        }

        public async Task UpdateLoanAfterApproveAsync(string loanNo, string apvStat)
        {
            Loan? loan = await dbContext.Loans.FirstOrDefaultAsync(a => a.LoanNo == loanNo);
            if (loan is null)
                throw new Exception("Loan Data Not Found");

            if (apvStat == APV_STAT_DECLINE)
            {
                loan.Status = LOAN_STATUS_DECLINE;
            }
            else
            {
                var nextInstDate = dbContext.InstalmentSchedules.First(a => a.LoanId == loan.Id).InstDate;
                loan.Status = LOAN_STATUS_LIVE;
                loan.GoLiveDate = DateTime.Now.Date;
                loan.CurrentDueNum = 1;
                loan.NextDueNum = 2;
                loan.NextDueDate = nextInstDate;
            }

            dbContext.Loans.Update(loan);
            await dbContext.SaveChangesAsync();
        }

        #region Loan Document
        public async Task CreateListLoanDocumentAsync(LoanDocumentDto payloads)
        {
            Loan loan = await BaseGetModelByIdAsync(payloads.LoanId);
            foreach (var payload in payloads.DocumentFiles)
            {
                LoanDocument loanDocument = new()
                {
                    FileName = payload.DocumentFiles.FileName,
                    FileExt = Path.GetExtension(payload.DocumentFiles.FileName),
                    RefLoanDocumentId = payload.RefLoanDocumentId,
                    FileSize = (int)payload.DocumentFiles.Length
                };

                await ValidateLoanDocument(loanDocument);
                string parentFolderId = await CheckLoanParentFolderAsync();
                loanDocument.FileUrl = await googleDriveService.GoogleDriveUploadFile(parentFolderId, loan.Id, payload.DocumentFiles);
                loan.LoanDocuments.Add(loanDocument);
            }

            dbContext.Loans.Update(loan);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<LoanDocumentViewDto>> GetLoanDocumentAsync(string loanid)
        {
            var data = await (from a in dbContext.LoanDocuments
                              join b in dbContext.RefLoanDocuments on a.RefLoanDocumentId equals b.Id
                              where a.LoanId == loanid
                              select new LoanDocumentViewDto
                              {
                                  Id = a.Id,
                                  RefLoanDocumentName= b.DocumentName,
                                  FilePreviewUrl = string.Format(GOOGLE_DRIVE_EMBEDED_PREFIX, a.FileUrl)
                              }).ToListAsync();

            return data;
        }

        //public async Task EditLoanDocumentAsync(string id)
        #endregion

        public async Task<PagingModel<LoanSchemeDto>> GetLoanSchemeListAsync(QueryParamDto queryParam)
        {
            IQueryable<LoanSchemeDto> query = dbContext.LoanSchemes.OrderBy(a => a.LoanSchemeName).Select(a => mapper.Map<LoanSchemeDto>(a));
            return await BaseGetPagingCustomResultAsync(queryParam, query);
        }

        public async Task CreateLoanGuaranteAsync(LoanGuaranteeCreateDto payloads)
        {
            Loan loan = await BaseGetModelByIdAsync(payloads.LoanId);
            List<string> listGuranteType = await refService.GetRefMasterValueByCodeAsync(REF_GURANTEE_TYPE_CODE);
            
            foreach (var payload in payloads.LoanGuaranteeFiles)
            {
                if (!listGuranteType.Contains(payload.GuaranteeType))
                    throw new Exception($"Invalid Gurantee Type ({payload.GuaranteeType})");

                LoanGuarantee loanGuarantee = new()
                {
                    Loan = loan,
                    GuaranteeName = payload.GuaranteeName,
                    GuaranteeType = payload.GuaranteeType,
                    LetterDate = payload.LetterDate,
                    LetterNo = payload.LetterNo,
                    LetterExpDate = payload.LetterExpDate,
                    OwnerName = payload.OwnerName
                };

                string parentFolderId = await CheckLoanParentFolderAsync();
                loanGuarantee.FileUrl = await googleDriveService.GoogleDriveUploadFile(parentFolderId, loan.Id, payload.File);
                loan.LoanGuarantees.Add(loanGuarantee);
            }

            dbContext.Loans.Update(loan);
            await dbContext.SaveChangesAsync();
        }

        #region Private Method
        private List<InstalmentSchedule> CalculateLoanInstSchdl(Loan loan)
        {
            List<InstalmentSchedule> oldInstSchdl = dbContext.InstalmentSchedules.Where(a => a.LoanId == loan.Id).ToList();
            if (oldInstSchdl.Any())
            {
                for (int i = 0; i < oldInstSchdl.Count; i++)
                    dbContext.InstalmentSchedules.Remove(oldInstSchdl[i]);
            }

            loan.LoanScheme = dbContext.LoanSchemes.First(a => a.Id == loan.LoanSchemeId);
            return instalmentService.CalculateInstalmentSchdl(loan.LoanDueNum, loan.LoanAmount, loan.EffectiveDate, loan.LoanScheme);
        }

        private async Task ValidateLoanDocument(LoanDocument model)
        {
            RefLoanDocument? docSetting = await dbContext.RefLoanDocuments.FindAsync(model.RefLoanDocumentId);
            if (docSetting is null)
                throw new Exception("Loan Document Setting is Not Found!");

            List<string> fileExtSetting = docSetting.AcceptedFileExt.Split(";").ToList();
            if (!fileExtSetting.Contains(model.FileExt.ToLower()))
                throw new Exception("Unmatch File Extension Setting with Uploaded File", 
                    new Exception($"Setting File is:[{docSetting.AcceptedFileExt}] | File Your Upload with Ext:[{model.FileExt}]"));

            if (model.FileSize > docSetting.MaxFileSize)
                throw new Exception("Max File Size has been Exeed!");
        }

        private async Task<string> CheckLoanParentFolderAsync()
        {
            string parentFolderId;
            DataAccess.Models.Commons.DriveFolderMap? driveFolder = await refService.GetDriveByNameAsync(LOAN_BASE_FOLDER);
            if (driveFolder is null)
            {
                parentFolderId = await googleDriveService.GoogleDriveCreateParentFolder(LOAN_BASE_FOLDER);
                await refService.CreateDriveFolderMapping(LOAN_BASE_FOLDER, parentFolderId);
            }
            else
            {
                parentFolderId = driveFolder.FolderId;
            }

            return parentFolderId;
        }
        #endregion

        #region Override Base Method
        protected override async Task<PagingModel<LoanDto>> BaseGetPagingDataDtoAsync(IQueryParam queryParam, IQueryable<Loan>? customquery = null)
        {
            IQueryable<LoanDto> query = from a in dbContext.Loans
                                        join b in dbContext.Members on a.MemberId equals b.Id
                                        join d in dbContext.LoanSchemes on a.LoanSchemeId equals d.Id
                                        where a.Status == LOAN_STATUS_NEW || a.Status == LOAN_STATUS_DECLINE
                                        select new LoanDto
                                        {
                                            Id = a.Id,
                                            CurrentDueNum = a.CurrentDueNum,
                                            LoanAmount = a.LoanAmount,
                                            LoanDate = a.LoanDate,
                                            LoanNo = a.LoanNo,
                                            LoanDueNum = a.LoanDueNum,
                                            NextDueNum = a.NextDueNum,
                                            Member = mapper.Map<MemberMinimalDto>(b),
                                            EffectiveDate = a.EffectiveDate,
                                            Status = a.Status,
                                            LoanScheme = mapper.Map<LoanSchemeDto>(d)
                                        };

            if (string.IsNullOrEmpty(queryParam.OrderBy))
                queryParam.OrderBy = nameof(LoanDto.LoanDate);

            return await PagingModel<LoanDto>.CreateAsync(query, queryParam);
        }
        #endregion

        #region Abstract Impl
        protected override Loan CreateNewModel(LoanCreateDto payload)
        {
            Loan loan = mapper.Map<Loan>(payload);
            loan.LoanNo = masterSequenceService.GenerateNo(LOAN_SEQ_CODE);
            loan.Status = LOAN_STATUS_NEW;
            loan.InstalmentSchedules = CalculateLoanInstSchdl(loan);

            return loan;
        }

        protected override DbSet<Loan> GetAppDbSet()
        {
            return dbContext.Loans;
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(Loan.LoanDate);
        }

        protected override void SetModelValue(Loan model, LoanEditDto payload)
        {
            model.LoanDate = payload.LoanDate;
            model.LoanDueNum = payload.LoanDueNum;
            model.EffectiveDate = payload.EffectiveDate;
            model.LoanPurpose = payload.LoanPurpose;
            model.LoanSchemeId = payload.LoanSchemeId;
            model.LoanAmount = payload.LoanAmount;
        }

        protected override IQueryable<Loan> SetQueryable()
        {
            return dbContext.Loans
                .AsNoTracking()
                .Include(a => a.Member)
                .Include(a => a.LoanScheme);
        }

        protected override void ValidateCreate(Loan model)
        {
            LoanScheme? loanScheme = dbContext.LoanSchemes.FirstOrDefault(a => a.Id == model.LoanSchemeId);
            if (loanScheme is null)
                throw new Exception("Loan Scheme Not Exist");

            if (model.LoanAmount > loanScheme.PlafondAmount)
                throw new Exception($"Jumlah pinjaman melebihi Palfond : {loanScheme.PlafondAmount}");

            if (model.LoanDueNum > loanScheme.DueNum)
                throw new OverTenorException($"{loanScheme.DueNum}");

            bool member = dbContext.Members.Any(a => a.Id == model.MemberId);
            if (!member)
                throw new Exception("Member Not Exist");

            if (dbContext.Loans.Any(a => a.MemberId == model.MemberId && a.Status != LOAN_STATUS_EXPIRED))
                throw new Exception("This Member Already have Active/On Process Loan Loan");

            decimal totalSaving = dbContext.Members
                .Where(a => a.Id == model.MemberId)
                .Join(dbContext.Savings, a => a.Id, b => b.MemberId, (a, b) => new {totSave = b.TotalAmount})
                .Sum(a => a.totSave);
            if (totalSaving <= 0)
                throw new Exception($"Simpanan Anggota sebesar {totalSaving}, Tidak dapat mengajukan pinjaman");
        }

        protected override void ValidateDelete(Loan model)
        {
            return;
        }

        protected override void ValidateEdit(Loan model)
        {
            LoanScheme? loanScheme = dbContext.LoanSchemes.FirstOrDefault(a => a.Id == model.LoanSchemeId);
            if (loanScheme is null)
                throw new Exception("Loan Scheme Not Exist");

            if (model.LoanAmount > loanScheme.PlafondAmount)
                throw new Exception($"Jumlah pinjaman melebihi Palfond : {loanScheme.PlafondAmount}");

            if (model.LoanDueNum > loanScheme.DueNum)
                throw new Exception("Jumlah Angsuran pinjaman melebihi Scheme");

            bool member = dbContext.Members.Any(a => a.Id == model.MemberId);
            if (!member)
                throw new Exception("Member Not Exist");
        }

        protected override LoanDto MappingToResultCrud(Loan model)
        {
            return base.MappingToResult(model);
        }
        #endregion
    }
}
