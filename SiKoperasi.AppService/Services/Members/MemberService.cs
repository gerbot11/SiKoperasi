using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Members;
using static SiKoperasi.AppService.Util.Constant;

namespace SiKoperasi.AppService.Services.Members
{
    public class MemberService : BaseCrudService<Member, MemberCreateDto, MemberEditDto, MemberDto, AppDbContext>, IMemberService
    {
        private readonly IMasterSequenceService masterSequenceService;
        private readonly ISavingService savingService;
        public MemberService(AppDbContext dbContext, IMapper mapper, IMasterSequenceService masterSequenceService, ISavingService savingService) 
            : base(dbContext, mapper)
        {
            this.masterSequenceService = masterSequenceService;
            this.savingService = savingService;
        }

        public async Task<MemberDto> CreateMemberAsync(MemberCreateDto payload)
        {
            return await BaseCreateAsync(payload);
        }

        public async Task<MemberDto> GetMemberAsync(string id)
        {
            return await BaseGetByIdAsync(id, true);
        }

        public async Task<Member> GetMemberModelAsync(string id)
        {
            return await BaseGetModelByIdAsync(id);
        }

        public async Task<PagingModel<MemberMinimalDto>> GetMemberPagingAsync(QueryParamDto queryParam)
        {
            IQueryable<MemberMinimalDto> query = from a in GetAppDbSet()
                                                 where a.IsActive
                                                 select new MemberMinimalDto
                                                 {
                                                     Id = a.Id,
                                                     MemberNo = a.MemberNo,
                                                     Name = a.Name,
                                                     IdNo = a.IdNo,
                                                     IdType = a.IdType,
                                                     PhoneNumber = a.PhoneNumber,
                                                     EmployeeNo = a.EmployeeNo
                                                 };

            return await BaseGetPagingCustomResultAsync<MemberMinimalDto>(queryParam, query);
        }

        public async Task<MemberDto> EditMemberAsync(MemberEditDto payload)
        {
            return await BaseEditAsync(payload.Id, payload);
        }

        public async Task DeleteMember(string id)
        {
            await BaseSafeDeleteAsync(id);
        }

        #region Abstract Implementation
        protected override Member CreateNewModel(MemberCreateDto payload)
        {
            Member newMember = mapper.Map<Member>(payload);
            newMember.MemberNo = masterSequenceService.GenerateNo(MEMBER_SEQ_CODE);
            newMember.IsActive = true;
            newMember.RegistrationDate = DateTime.Now.Date;
            newMember.Savings = savingService.CreateSaving();
            newMember.Address = mapper.Map<Address>(payload.Address);
            newMember.Job = mapper.Map<Job>(payload.Job);
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
            model.IdType = payload.IdType;
            model.Gender = payload.Gender;
            model.BirthDate = payload.BirthDate;
            model.BirthPlace = payload.BirthPlace;
            model.PhoneNumber = payload.PhoneNumber;
            model.NpwpNo = payload.NpwpNo;

            model.Address = dbContext.Addresses.Single(a => a.MemberId == model.Id);
            model.Address.Description = payload.Address.Description;
            model.Address.AddressType = payload.Address.AddressType;
            model.Address.Rt = payload.Address.Rt;
            model.Address.Rw = payload.Address.Rw;
            model.Address.ProvinceId = payload.Address.ProvinceId;
            model.Address.CityId = payload.Address.CityId;
            model.Address.DistrictId = payload.Address.DistrictId;
            model.Address.SubDistrictId = payload.Address.SubDistrictId;

            model.Job = dbContext.Jobs.Single(a => a.MemberId == model.Id);
            model.Job.Company = payload.Job.Company;
            model.Job.JobName = payload.Job.JobName;
            model.Job.JobPosition = payload.Job.JobPosition;
            model.Job.JobDescription = payload.Job.JobDescription;
            model.Job.JobDepartment = payload.Job.JobDepartment;
            model.Job.StartDate = payload.Job.StartDate;
        }

        protected override IQueryable<Member> SetQueryable()
        {
            return dbContext.Members.Where(a => a.IsActive)
                .AsNoTracking()
                .Include(a => a.Job)
                .Select(a => new Member
                {
                    Id = a.Id,
                    BirthDate = a.BirthDate,
                    BirthPlace = a.BirthPlace,
                    EmployeeNo = a.EmployeeNo,
                    MemberNo = a.MemberNo,
                    Gender = a.Gender,
                    IdNo = a.IdNo,
                    IdType = a.IdType,
                    MartialStat = a.MartialStat,
                    NpwpNo = a.NpwpNo,
                    Name = a.Name,
                    RegistrationDate = a.RegistrationDate,
                    PhoneNumber = a.PhoneNumber,
                    Address = dbContext.Addresses.Where(x => x.MemberId == a.Id)
                                .Include(a => a.Province)
                                .Include(a => a.City)
                                .Include(a => a.District)
                                .Include(a => a.SubDistrict).Single(),
                    Job = a.Job,
                });
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
            return;
        }

        protected override void ValidateEdit(Member model)
        {
            if (dbContext.Members.Any(a => a.IdNo == model.IdNo && a.Id != model.Id))
            {
                throw new Exception($"Duplicate Member with ID No '{model.IdNo}'");
            }
        }

        protected override MemberDto MappingToResultCrud(Member model)
        {
            model.Address.City = dbContext.Cities.Single(a => a.Id == model.Address.CityId);
            model.Address.Province = dbContext.Provinces.Single(a => a.Id == model.Address.ProvinceId);
            model.Address.District = dbContext.Districts.Single(a => a.Id == model.Address.DistrictId);
            model.Address.SubDistrict = dbContext.SubDistricts.Single(a => a.Id == model.Address.SubDistrictId);
            return MappingToResult(model);
        }
        #endregion
    }
}
