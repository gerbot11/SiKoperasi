using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.Core.Common;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.AppService.Services.Members
{
    public class MemberService : BaseCrudService<Member, MemberCreateDto, MemberEditDto, MemberDto, AppDbContext>, IMemberService
    {
        public MemberService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task CreateMemberAsync(MemberCreateDto payload)
        {
            await BaseCreateAsync(payload);
        }

        protected override Member CreateNewModel(MemberCreateDto payload)
        {
            Member member = new()
            {
                Name = payload.Name,
                IdNo = payload.IdNo,
                IdType = payload.IdType,
                Gender = payload.Gender,
                BirthPlace = payload.BirthPlace,
                BirthDate = payload.BirthDate,
                NpwpNo = payload.NpwpNo
            };

            return member;
        }

        #region Abstract Implementation
        protected override DbSet<Member> GetAppDbSet()
        {
            return dbContext.Members;
        }

        protected override void SetModelValue(Member model, MemberEditDto payload)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<Member> SetQueryable()
        {
            return dbContext.Members;
        }

        protected override void ValidateCreate(Member model)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateDelete(Member model)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateEdit(Member model)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
