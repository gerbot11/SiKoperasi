﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Member;
using SiKoperasi.Core.Common;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Members;

namespace SiKoperasi.AppService.Services.Members
{
    public class AddressService : BaseCrudService<Address, AddressCreateDto, AddressEditDto, AddressDto, AppDbContext>, IAddressService
    {
        private readonly IMemberService memberService;
        public AddressService(AppDbContext dbContext, IMapper mapper, IMemberService memberService) : base(dbContext, mapper)
        {
            this.memberService = memberService;
        }

        public async Task CreateAddressAsync(AddressCreateDto payload)
        {
            await BaseCreateAsync(payload);
        }

        public async Task EditAddressAsync(AddressEditDto payload)
        {
            await BaseEditAsync(payload.Id, payload);
        }

        public async Task<AddressDto> GetAddressAsync(string id)
        {
            return await GetByIdAsync(id);
        }

        public async Task DeleteAddressAsync(string id)
        {
            await BaseDeleteAsync(id);
        }

        public async Task<IEnumerable<AddressDto>> GetAddressDtoByMemberAsync(string memberId)
        {
            IEnumerable<AddressDto> result = await (from a in dbContext.Addresses
                                                    where a.MemberId == memberId
                                                    select new AddressDto
                                                    {
                                                        MemberId = a.MemberId,
                                                        AddressType = a.AddressType,
                                                        CityId = a.CityId,
                                                        Description = a.Description,
                                                        DistrictId = a.DistrictId,
                                                        ProvinceId = a.ProvinceId,
                                                        Rt = a.Rt,
                                                        Rw = a.Rw,
                                                        SubDistrictId = a.SubDistrictId
                                                    }).ToListAsync();

            return result;
        }

        #region Abstract Implement
        protected override Address CreateNewModel(AddressCreateDto payload)
        {
            return mapper.Map<Address>(payload);
        }

        protected override DbSet<Address> GetAppDbSet()
        {
            return dbContext.Addresses;
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(Address.DtmCrt);
        }

        protected override void SetModelValue(Address model, AddressEditDto payload)
        {
            model.AddressType = payload.AddressType; 
            model.Description = payload.Description;
            model.Rt = payload.Rt;
            model.Rw = payload.Rw;
            model.ProvinceId = payload.ProvinceId;
            model.CityId = payload.CityId;
            model.DistrictId = payload.DistrictId;
            model.SubDistrictId = payload.SubDistrictId;
        }

        protected override IQueryable<Address> SetQueryable()
        {
            return dbContext.Addresses;
        }

        protected override void ValidateCreate(Address model)
        {
            CheckIsMemberExist(model.MemberId);
        }

        protected override void ValidateDelete(Address model)
        {
            if (dbContext.Addresses.Where(a => a.MemberId == model.MemberId).Count() <= 1)
                throw new Exception("Can't Delete Last of Address");
        }

        protected override void ValidateEdit(Address model)
        {
            CheckIsMemberExist(model.MemberId);
        }
        #endregion

        #region Additional Private Method
        private void CheckIsMemberExist(string memberId)
        {
            if (!dbContext.Members.Any(a => a.Id == memberId))
                throw new Exception($"Member with Id {memberId} not Exist For Adding Address");
        }
        #endregion
    }
}
