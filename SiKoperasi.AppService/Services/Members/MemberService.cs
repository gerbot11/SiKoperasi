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
        private readonly ICityService cityService;
        private readonly IProvinceService provinceService;
        private readonly IDistrictService districtService;
        private readonly ISubDistrictService subDistrictService;
        public MemberService(AppDbContext dbContext, IMapper mapper, 
            ICityService cityService, IProvinceService provinceService, IDistrictService districtService, ISubDistrictService subDistrictService) : base(dbContext, mapper)
        {
            this.cityService = cityService;
            this.provinceService = provinceService;
            this.districtService = districtService;
            this.subDistrictService = subDistrictService;
        }

        public async Task CreateMemberAsync(MemberCreateDto payload)
        {
            await BaseCreateAsync(payload);
        }

        #region Abstract Implementation
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
                NpwpNo = payload.NpwpNo,
            };

            foreach (AddressCreateDto item in payload.Address)
            {
                Address address = new()
                {
                    AddressType = item.AddressType,
                    Description = item.Description,
                    Rt = item.Rt,
                    Rw = item.Rw,
                    Province = provinceService.GetProvinceModel(item.ProvinceId),
                    City = cityService.GetCity(item.CityId),
                    District = districtService.GetDistrictModel(item.DistrictId),
                    SubDistrict = subDistrictService.GetSubDistrictModel(item.SubDistrictId),
                };

                member.Addresses.Add(address);
            }

            return member;
        }

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
