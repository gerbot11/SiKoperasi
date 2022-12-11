using AutoMapper;
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

        public async Task CreateSubDistrictAsync(SubDistrictCreateDto payload)
        {
            await BaseCreateAsync(payload);
        }

        public SubDistrict GetSubDistrictModel(string id)
        {
            return GetModelById(id);
        }

        protected override SubDistrict CreateNewModel(SubDistrictCreateDto payload)
        {
            SubDistrict subDistrict = new()
            {
                Name = payload.Name,
                Code = payload.Code,
                PostalCode = payload.PostalCode,
                DistrictId = payload.DistrictId,
            };

            return subDistrict;
        }

        protected override DbSet<SubDistrict> GetAppDbSet()
        {
            return dbContext.SubDistricts;
        }

        protected override void SetModelValue(SubDistrict model, SubDistrictEditDto payload)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<SubDistrict> SetQueryable()
        {
            return dbContext.SubDistricts;
        }

        protected override void ValidateCreate(SubDistrict model)
        {
            return;
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
