﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.SubDistrict;
using SiKoperasi.Core.Common;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Services.Master
{
    public class SubDistrictService : BaseCrudService<SubDistrict, SubDistrictCreateDto, SubDistrictEditDto, SubDistrictDto, AppDbContext>, ISubDistrictService
    {
        public SubDistrictService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public SubDistrict GetSubDistrictModel(string id)
        {
            throw new NotImplementedException();
        }

        protected override SubDistrict CreateNewModel(SubDistrictCreateDto payload)
        {
            throw new NotImplementedException();
        }

        protected override DbSet<SubDistrict> GetAppDbSet()
        {
            throw new NotImplementedException();
        }

        protected override void SetModelValue(SubDistrict model, SubDistrictEditDto payload)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<SubDistrict> SetQueryable()
        {
            throw new NotImplementedException();
        }

        protected override void ValidateCreate(SubDistrict model)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateDelete(SubDistrict model)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateEdit(SubDistrict model)
        {
            throw new NotImplementedException();
        }
    }
}