using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.AppService.Services.Members
{
    public class MemberService : BaseCrudService<Member, MemberCreateDto, MemberEditDto, MemberDto, AppDbContext>, IMemberService
    {
        private readonly IMasterSequenceService masterSequenceService;
        public MemberService(AppDbContext dbContext, IMapper mapper, IMasterSequenceService masterSequenceService) 
            : base(dbContext, mapper)
        {
            this.masterSequenceService = masterSequenceService;
        }

        public async Task<MemberDto> CreateMemberAsync(MemberCreateDto payload)
        {
            return await BaseCreateAsync(payload);
        }

        public async Task<MemberDto> GetMemberAsync(string id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<PagingModel<MemberDto>> GetMemberPagingAsync(QueryParamDto queryParam)
        {
            return await GetPagingDataDtoAsync(queryParam);
        }

        public async Task<MemberDto> EditMemberAsync(MemberEditDto payload)
        {
            return await BaseEditAsync(payload.Id, payload);
        }

        public async Task DeleteMember(string id)
        {
            await BaseDeleteAsync(id);
        }

        #region Abstract Implementation
        protected override Member CreateNewModel(MemberCreateDto payload)
        {
            Member newMember = mapper.Map<Member>(payload);
            newMember.MemberNo = masterSequenceService.GenerateNo(Member.MEMBER_SEQ_CODE);
            newMember.IsActive = true;
            return newMember;
        }

        protected override DbSet<Member> GetAppDbSet()
        {
            return dbContext.Members;
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(Member.Name);
        }

        protected override void SetModelValue(Member model, MemberEditDto payload)
        {
            model.Name = payload.Name;
            model.IdNo = payload.IdNo;
            model.IsActive = payload.IsActive;
            model.IdType = payload.IdType;
            model.Gender = payload.Gender;
            model.BirthDate = payload.BirthDate;
            model.BirthPlace = payload.BirthPlace;
            model.PhoneNumber = payload.PhoneNumber;
            model.NpwpNo = payload.NpwpNo;
        }

        protected override IQueryable<Member> SetQueryable()
        {
            return dbContext.Members;
        }

        protected override void ValidateCreate(Member model)
        {
            if (dbContext.Members.Any(a => a.IdNo == model.IdNo))
            {
                throw new Exception($"Duplicate Member with ID No '{model.IdNo}'");
            }
        }

        protected override void ValidateDelete(Member model)
        {
            throw new Exception("Ga Bisa Hapus Member Bang, Banyak Relasi! (set inactive aja)");
        }

        protected override void ValidateEdit(Member model)
        {
            if (dbContext.Members.Any(a => a.IdNo == model.IdNo))
            {
                throw new Exception($"Duplicate Member with ID No '{model.IdNo}'");
            }
        }
        #endregion
    }
}
