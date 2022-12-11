using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.District;
using SiKoperasi.Core.Common;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Services.Master
{
    public class DistrictService : BaseCrudService<District, DistrictCreateDto, DistrictEditDto, DistrictDto, AppDbContext>, IDistrictService
    {
        public DistrictService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task CreateDistrictAsync(DistrictCreateDto dto)
        {
            await BaseCreateAsync(dto);
        }

        public District GetDistrictModel(string id)
        {
            return GetModelById(id);
        }

        #region Abstract Implementation
        protected override District CreateNewModel(DistrictCreateDto payload)
        {
            District district = new()
            {
                Name = payload.Name,
                Code = payload.Code,
                CityId = payload.CityId,
            };

            return district;
        }

        protected override DbSet<District> GetAppDbSet()
        {
            return dbContext.Districts;
        }

        protected override void SetModelValue(District model, DistrictEditDto payload)
        {
            return;
        }

        protected override IQueryable<District> SetQueryable()
        {
            return dbContext.Districts;
        }

        protected override void ValidateCreate(District model)
        {
            return;
        }

        protected override void ValidateDelete(District model)
        {
            return;
        }

        protected override void ValidateEdit(District model)
        {
            return;
        }
        #endregion
    }
}
