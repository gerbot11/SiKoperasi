using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Approval;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Loan;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Approvals;
using static SiKoperasi.AppService.Util.Constant;

namespace SiKoperasi.AppService.Services.Approval
{
    public class ApprovalService : BaseSimpleService<AppDbContext>, IApprovalService
    {
        public ApprovalService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task CreateNewApvRequestAsync(ApprovalReqDto reqDto)
        {
            ApvScheme? scheme = await dbContext.ApvSchemes.SingleOrDefaultAsync(a => a.Code == reqDto.SchmeCode);
            if (scheme == null)
                throw new Exception($"Approval Scheme:{reqDto.SchmeCode} Not Found");

            scheme.ApvSchemeNodes = await dbContext.ApvSchemeNodes.Where(a => a.ApvSchemeId == scheme.Id).ToListAsync();

            ApvReq req = new()
            {
                ApvScheme = scheme,
                TrxNo = reqDto.TrxNo,
                Notes = reqDto.Notes,
                RequestBy = reqDto.ReqBy,
                RequestDate = DateTime.Now.Date,
                ApvStatus = LOAN_STATUS_REQ
            };

            foreach (ApvSchemeNode item in scheme.ApvSchemeNodes)
            {
                ApvReqTask task = new()
                {
                    IsClaimed = false,
                    IsDone = false,
                    IsFinal = false,
                    ApvSeq = item.Level,
                    ApvSchemeNode = item,
                };

                req.ApvReqTasks.Add(task);
            }

            dbContext.Add(req);
            await dbContext.SaveChangesAsync();
        }

        public async Task<PagingModel<ApprovalDto>> GetApprovalReqPagingAsync(QueryParamDto queryParam)
        {
            var query = from a in dbContext.ApvReqs
                        join c in dbContext.ApvSchemes on a.ApvSchemeId equals c.Id
                        select new ApprovalDto
                        {
                            ApprovalSchemeName = c.Name,
                            ApvType = c.ApvType,
                            TrxNo = a.TrxNo,
                            ReqBy = a.RequestBy,
                            ApvStat = a.ApvStatus,
                            Id = a.Id,
                            RequestDate = a.RequestDate,
                            Task = dbContext.ApvReqTasks
                                .Where(x => x.ApvReqId == a.Id && !x.IsDone)
                                .OrderBy(x => x.ApvSeq)
                                .Select(x => new ApprovalTaskDto
                                {
                                    TaskId = x.Id,
                                    ClaimedBy = x.UserId ?? "",
                                    IsClaimed = x.IsClaimed
                                }).FirstOrDefault(),
                        };

            queryParam.OrderBy ??= nameof(ApprovalDto.RequestDate);
            queryParam.OrderBehavior ??= Core.Enums.OrderBehaviour.Desc;

            return await PagingModel<ApprovalDto>.CreateAsync(query, queryParam);
        }

        public async Task<ApprovalLoanDetailDto> ClaimApprovalTaskAsync(ApprovalDto payload, string currentUser)
        {
            ApvReq? req = await dbContext.ApvReqs.FindAsync(payload.Id);
            if (req is null)
                throw new Exception("Approval Request Not Found");

            if (payload.Task is null)
                throw new Exception("Approval Task Not Found");

            ApvReqTask taskToClaim = await dbContext.ApvReqTasks.SingleAsync(a => a.Id == payload.Task.TaskId);

            if (taskToClaim.IsClaimed)
                throw new Exception($"Approval Task Already Claimed by:{taskToClaim.UserId}");

            var queryLoan = await (from a in dbContext.Loans
                                   join b in dbContext.Members on a.MemberId equals b.Id
                                   join c in dbContext.LoanSchemes on a.LoanSchemeId equals c.Id
                                   where a.LoanNo == req.TrxNo
                                   select new LoanDto
                                   {
                                       Member = mapper.Map<MemberMinimalDto>(b),
                                       LoanScheme = mapper.Map<LoanSchemeDto>(c),
                                       Id = a.Id,
                                       CurrentDueNum = a.CurrentDueNum,
                                       EffectiveDate = a.EffectiveDate,
                                       LoanAmount = a.LoanAmount,
                                       LoanDate = a.LoanDate,
                                       LoanDueNum = a.LoanDueNum,
                                       LoanNo = a.LoanNo,
                                       NextDueNum = a.NextDueNum,
                                       Status = a.Status
                                   }).FirstAsync();

            var queryReqHist = await (from a in dbContext.ApvReqTasks
                                      where a.ApvReqId == payload.Id
                                      select new ApprovalHistDto
                                      {
                                          ApproveDate = a.ApproveDate,
                                          ClaimedBy = a.UserId,
                                          Notes = a.ResultNotes
                                      }).ToListAsync();

            ApprovalLoanDetailDto result = await (from a in dbContext.ApvReqs
                                                 join c in dbContext.ApvSchemes on a.ApvSchemeId equals c.Id
                                                 select new ApprovalLoanDetailDto
                                                 {
                                                     ApprovalHists = queryReqHist,
                                                     Loan = queryLoan,
                                                     ApprovalSchemeName = c.Name,
                                                     ApvType = c.ApvType,
                                                     Id = a.Id,
                                                     ReqBy = a.RequestBy,
                                                     TrxNo = a.TrxNo
                                                 }).FirstAsync();

            
            taskToClaim.IsClaimed = true;
            taskToClaim.UserId = currentUser;
            taskToClaim.ProcessDate = DateTime.Now;

            dbContext.ApvReqTasks.Update(taskToClaim);
            await dbContext.SaveChangesAsync();
            return result;
        }

        public async Task ProcessApprovalAsync(ApprovalProcessDto payload)
        {
            string[] apvStat = { APV_STAT_APV, APV_STAT_DECLINE };
            if (!apvStat.Contains(payload.ApvStat))
                throw new Exception("Invalid Apv Status Code should be 'APV' or 'DEC'");

            ApvReq? req = await dbContext.ApvReqs.FirstOrDefaultAsync(a => a.TrxNo == payload.TrxNo && a.ApvStatus == APV_STAT_REQ);
            if (req is null)
                throw new Exception($"Cant Find Approval Request No:{payload.TrxNo}");

            req.ApvReqTasks = await dbContext.ApvReqTasks.Where(a => a.ApvReqId == req.Id).ToListAsync();

            if (payload.ApvStat == APV_STAT_DECLINE)
            {
                req.ApvStatus = APV_STAT_DECLINE;
                req.FinishDate = DateTime.Now.Date;
                foreach (var item in req.ApvReqTasks)
                {
                    item.IsDone = true;
                    if (item.IsClaimed)
                    {
                        item.ResultNotes = payload.Notes;
                    }
                }

                dbContext.ApvReqs.Update(req);
                await dbContext.SaveChangesAsync();
                return;
            }

            if (payload.IsFinal)
            {
                req.ApvStatus = APV_STAT_APV;
                req.FinishDate = DateTime.Now.Date;
                foreach (var item in req.ApvReqTasks)
                {
                    if (item.IsClaimed && !item.IsDone)
                    {
                        item.IsDone = true;
                        item.IsFinal = true;
                        item.ApproveDate = DateTime.Now;
                        item.ResultNotes = payload.Notes;
                    }
                    else
                    {
                        item.IsDone = true;
                    }
                }

                dbContext.ApvReqs.Update(req);
                await dbContext.SaveChangesAsync();
            }
            else
            {
                foreach (var item in req.ApvReqTasks.Where(a => a.IsClaimed && !a.IsDone))
                {
                    item.IsDone = true;
                    item.ApproveDate = DateTime.Now;
                    item.ResultNotes = payload.Notes;
                }

                dbContext.ApvReqs.Update(req);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
