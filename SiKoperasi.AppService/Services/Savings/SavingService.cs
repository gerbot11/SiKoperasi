using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.AppService.Dto.Saving;
using SiKoperasi.Core.Common;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Members;
using SiKoperasi.DataAccess.Models.Savings;

namespace SiKoperasi.AppService.Services.Savings
{
    public class SavingService : BaseService<Saving, SavingDto, AppDbContext>, ISavingService
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
                                }).ToListAsync();

            MemberSavingDto savingDto = new()
            {
                Member = memberDto,
                Savings = savings
            };

            return savingDto;
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
            return nameof(Saving.Member.Name);
        }

        protected override IQueryable<Saving> SetQueryable()
        {
            return dbContext.Savings.Include(a => a.Member);
        }
    }
}
