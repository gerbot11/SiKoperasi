using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.City;
using SiKoperasi.Core.Common;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Services.Master
{
    public class CityService : BaseCrudService<City, CityCreateDto, CityEditDto, CityDto, AppDbContext>, ICityService
    {
        public CityService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task CreateCityAsync(CityCreateDto payload)
        {
            await BaseCreateAsync(payload);
        }

        public async Task<City> GetCityAsync(string id)
        {
            return await GetModelByIdAsync(id);
        }

        public City GetCity(string id)
        {
            return GetModelById(id);
        }

        protected override City CreateNewModel(CityCreateDto payload)
        {
            throw new NotImplementedException();
        }

        protected override DbSet<City> GetAppDbSet()
        {
            return dbContext.Cities;
        }

        protected override void SetModelValue(City model, CityEditDto payload)
        {
            throw new NotImplementedException();
        }

        protected override IQueryable<City> SetQueryable()
        {
            return dbContext.Cities;
        }

        protected override void ValidateCreate(City model)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateDelete(City model)
        {
            throw new NotImplementedException();
        }

        protected override void ValidateEdit(City model)
        {
            throw new NotImplementedException();
        }
    }
}
