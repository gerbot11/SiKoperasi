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

        public Task CreateMemberAsync(MemberCreateDto payload)
        {
            throw new NotImplementedException();
        }

        protected override Member CreateNewModel(MemberCreateDto payload)
        {
            throw new NotImplementedException();
        }

        protected override DbSet<Member> GetAppDbSet()
        {
            throw new NotImplementedException();
        }

        protected override void SetModelValue(Member model, MemberEditDto payload)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<Member> SetQueryable()
        {
            throw new NotImplementedException();
        }

        protected override void ValidateCreate(Member model)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateDelete(Member model)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateEdit(Member model, string id)
        {
            throw new NotImplementedException();
        }
    }
}
