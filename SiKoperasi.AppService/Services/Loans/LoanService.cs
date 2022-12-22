using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Loans;

namespace SiKoperasi.AppService.Services.Loans
{
    public class LoanService : BaseCrudService<Loan, LoanCreateDto, LoanEditDto, LoanDto, AppDbContext>, ILoanService
    {
        private readonly IMasterSequenceService masterSequenceService;
        private readonly IInstalmentService instalmentService;
        public LoanService(AppDbContext dbContext, IMapper mapper, IMasterSequenceService masterSequenceService, IInstalmentService instalmentService) : base(dbContext, mapper)
        {
            this.masterSequenceService = masterSequenceService;
            this.instalmentService = instalmentService;
        }

        public async Task<LoanDto> GetLoanAsync(string id)
        {
            return await BaseGetByIdAsync(id);
        }

        public async Task<PagingModel<LoanDto>> GetLoanPagingAsync(QueryParamDto queryParam)
        {
            return await BaseGetPagingDataDtoAsync(queryParam);
        }

        public async Task<LoanDto> CreateLoanAsync(LoanCreateDto payload)
        {
            return await BaseCreateAsync(payload);
        }

        public async Task<List<InstSchdlDto>> CalculateLoanInstSchdl(string loanid)
        {
            Loan loan = BaseGetModelById(loanid);
            List<InstalmentSchedule> oldInstSchdl = dbContext.InstalmentSchedules.Where(a => a.LoanId == loanid).ToList();
            if (oldInstSchdl.Any())
            {
                for (int i = 0; i < oldInstSchdl.Count; i++)
                    dbContext.InstalmentSchedules.Remove(oldInstSchdl[i]);
            }

            loan.LoanScheme = dbContext.LoanSchemes.First(a => a.Id == loan.LoanSchemeId);
            var listInstSchdl = instalmentService.CalculateInstalmentSchdl(loan);

            loan.InstalmentSchedules = listInstSchdl;
            dbContext.Loans.Update(loan);
            await dbContext.SaveChangesAsync();

            return mapper.Map<ICollection<InstalmentSchedule>, List<InstSchdlDto>>(loan.InstalmentSchedules);
        }

        public async Task CreateLoanDocumentAsync(List<LoanDocumentDto> payload, string loanid)
        {
            Loan loan = await BaseGetModelByIdAsync(loanid);
            
            foreach (var item in payload)
            {
                LoanDocument loanDocument = new()
                {
                    FileName = item.DocumentFiles.FileName,
                    FileExt = Path.GetExtension(item.DocumentFiles.FileName),
                    RefLoanDocumentId = item.RefLoanDocumentId,
                    FileSize = (int)item.DocumentFiles.Length,
                    FileUrl = "No Available Yet"
                };

                await ValidateLoanDocument(loanDocument);
                loan.LoanDocuments.Add(loanDocument);
            }

            dbContext.Loans.Update(loan);
            await dbContext.SaveChangesAsync();
        }

        #region Private Method
        private async Task ValidateLoanDocument(LoanDocument model)
        {
            RefLoanDocument? docSetting = await dbContext.RefLoanDocuments.FindAsync(model.RefLoanDocumentId);
            if (docSetting is null)
                throw new Exception("Loan Document Setting is Not Found!");

            List<string> fileExtSetting = docSetting.AcceptedFileExt.Split(";").ToList();
            if (!fileExtSetting.Contains(model.FileExt))
                throw new Exception("Unmatch File Extension Setting with Uploaded File");

            if (model.FileSize > docSetting.MaxFileSize)
                throw new Exception("Max File Size has been Exeed!");
        }
        #endregion

        #region Override Base Method
        protected override async Task<PagingModel<LoanDto>> BaseGetPagingDataDtoAsync(IQueryParam queryParam, IQueryable<Loan>? customquery = null)
        {
            IQueryable<LoanDto> query = from a in dbContext.Loans
                                        join b in dbContext.Members on a.MemberId equals b.Id
                                        let c = dbContext.Addresses.FirstOrDefault(a => a.AddressType.ToLower() == "legal" && a.MemberId == b.Id)
                                        where a.Status == Loan.LOAN_STATUS_NEW || a.Status == Loan.LOAN_STATUS_RETURN
                                        select new LoanDto
                                        {
                                            Id = a.Id,
                                            CurrentDueNum = a.CurrentDueNum,
                                            LoanAmount = a.LoanAmount,
                                            LoanDate = a.LoanDate,
                                            LoanNo = a.LoanNo,
                                            LoanSchemeId = a.LoanSchemeId,
                                            NextDueNum = a.NextDueNum,
                                            MemberId = a.MemberId,
                                            MemberName = b.Name,
                                            MemberAddress = c.Description,
                                            EffectiveDate = a.EffectiveDate,
                                            Status = a.Status
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
            loan.LoanNo = masterSequenceService.GenerateNo(Loan.LOAN_SEQ_CODE);
            loan.Status = Loan.LOAN_STATUS_NEW;

            return loan;
        }

        protected override DbSet<Loan> GetAppDbSet()
        {
            return dbContext.Loans;
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(Loan.DtmUpd);
        }

        protected override void SetModelValue(Loan model, LoanEditDto payload)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<Loan> SetQueryable()
        {
            return dbContext.Loans;
        }

        protected override void ValidateCreate(Loan model)
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

        protected override void ValidateDelete(Loan model)
        {
            return;
        }

        protected override void ValidateEdit(Loan model)
        {
            return;
        }
        #endregion
    }
}
