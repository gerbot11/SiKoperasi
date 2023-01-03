using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.AppService.Dto.Saving;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Members;
using SiKoperasi.DataAccess.Models.Savings;

namespace SiKoperasi.AppService.Services.Savings
{
    public class SavingService : BaseService<Saving, SavingMinimalDto, AppDbContext>, ISavingService
    {
        public SavingService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public List<Saving> CreateSaving()
        {
            IEnumerable<RefSavingType> listSavingType = GetListRefSavingType();
            if (!listSavingType.Any())
                throw new Exception("Saving Type Not Setting Yet");

            List<Saving> result = new();
            foreach (var item in listSavingType)
            {
                Saving saving = new()
                {
                    CutAmount = 0,
                    TotalAmount = 0,
                    RefSavingType = item
                };

                result.Add(saving);
            }

            return result;
        }

        public async Task<MemberSavingDto> GetMemberSavingAsync(string memberid)
        {
            Member? member = await dbContext.Members.FindAsync(memberid);
            if (member is null)
                throw new Exception("Member Data Not Exist");

            MemberDto memberDto = mapper.Map<MemberDto>(member);

            var savings = await (from a in dbContext.Savings
                                join c in dbContext.RefSavingTypes on a.RefSavingTypeId equals c.Id
                                where a.MemberId == memberid
                                select new SavingDto
                                {
                                    Id = a.Id,
                                    CutAmount = a.CutAmount,
                                    SavingType = c.SavingName,
                                    TotalAmount = a.TotalAmount,
                                    IsWithdrawal = c.IsWithdrawal
                                }).ToListAsync();

            MemberSavingDto savingDto = new(memberDto, savings);
            return savingDto;
        }

        public async Task<PagingModel<SavingMinimalDto>> GetSavingPagingAsync(QueryParamDto queryParam)
        {
            queryParam.OrderBehavior ??= Core.Enums.OrderBehaviour.Asc;
            queryParam.OrderBy ??= nameof(SavingMinimalDto.MemberName);

            IQueryable<SavingMinimalDto> query = from a in dbContext.Members
                                                 where a.IsActive
                                                 let b = dbContext.Savings.Where(x => x.MemberId == a.Id).Sum(x => x.TotalAmount - x.CutAmount)
                                                 select new SavingMinimalDto
                                                 {
                                                     EmployeeNo = a.EmployeeNo,
                                                     MemberNo = a.MemberNo,
                                                     MemberId = a.Id,
                                                     MemberName = a.Name,
                                                     TotalAmount = b
                                                 };

            return await PagingModel<SavingMinimalDto>.CreateAsync(query, queryParam);
        }

        public async Task<PagingModel<RefSavingTypeDto>> GetPagingSavingTypeAsync(QueryParamDto queryParam)
        {
            queryParam.OrderBehavior ??= Core.Enums.OrderBehaviour.Asc;
            queryParam.OrderBy ??= nameof(RefSavingType.SavingName);

            var query = from a in dbContext.RefSavingTypes
                        where a.IsActive
                        select new RefSavingTypeDto
                        {
                            SavingName = a.SavingName,
                            MinimalAmountDeposit = a.MinimalAmountDeposit,
                            CutAmount = a.CutAmount,
                            IsMandatory = a.IsMandatory,
                            IsActive = a.IsActive,
                            SavingRate = a.SavingRate,
                            IsWithdrawal = a.IsWithdrawal
                        };

            return await PagingModel<RefSavingTypeDto>.CreateAsync(query, queryParam);
        }

        private IEnumerable<RefSavingType> GetListRefSavingType()
        {
            return dbContext.RefSavingTypes.Where(a => a.IsActive == true);
        }

        protected override DbSet<Saving> GetAppDbSet()
        {
            return dbContext.Savings;
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(Saving.DtmCrt);
        }

        protected override IQueryable<Saving> SetQueryable()
        {
            return dbContext.Savings.Include(a => a.Member);
        }
    }
}
