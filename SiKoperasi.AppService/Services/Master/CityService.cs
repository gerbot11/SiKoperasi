using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.City;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
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

        public async Task<CityDto> GetCityAsync(string id)
        {
            return await BaseGetByIdAsync(id);
        }

        public async Task<PagingModel<CityDto>> GetCityPagingAsync(QueryParamDto queryParam)
        {
            return await BaseGetPagingDataDtoAsync(queryParam);
        }

        public City GetCity(string id)
        {
            return BaseGetModelById(id);
        }

        public async Task<PagingModel<CityDto>> GetListCityByProvinceAsync(string provinceid, QueryParamDto queryParam)
        {
            IQueryable<City> query = dbContext.Cities.Where(a => a.ProvinceId == provinceid);
            return await BaseGetPagingDataDtoAsync(queryParam, query);
        }

        protected override City CreateNewModel(CityCreateDto payload)
        {
            City city = new()
            {
                Name = payload.Name,
                Code = payload.Code,
                ProvinceId = payload.ProvinceId
            };

            return city;
        }

        protected override DbSet<City> GetAppDbSet()
        {
            return dbContext.Cities;
        }

        protected override void SetModelValue(City model, CityEditDto payload)
        {
            return;
        }

        protected override IQueryable<City> SetQueryable()
        {
            return dbContext.Cities;
        }

        protected override void ValidateCreate(City model)
        {
            if (!dbContext.Provinces.Any(a => a.Id == model.ProvinceId))
            {
                throw new Exception("Province is Not Exist");
            }
        }

        protected override void ValidateDelete(City model)
        {
            return;
        }

        protected override void ValidateEdit(City model)
        {
            return;
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(City.Name);
        }
    }
}
