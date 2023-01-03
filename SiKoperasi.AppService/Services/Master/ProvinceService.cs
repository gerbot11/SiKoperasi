using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Province;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Services.Master
{
    public class ProvinceService : BaseCrudService<Province, ProvinceCreateDto, ProvinceEditDto, ProvinceDto, AppDbContext>, IProvinceService
    {
        public ProvinceService(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<PagingModel<Province>> GetProvincePagingAsync(QueryParamDto dto)
        {
            return await BaseGetPagingDataAsync(dto);
        }

        public async Task<ProvinceDto> GetProvinceAsync(string id)
        {
            ProvinceDto data = await BaseGetByIdAsync(id);
            return data;
        }

        public Province GetProvinceModel(string id)
        {
            return BaseGetModelById(id);
        }

        public async Task CreateProvinceAsync(ProvinceCreateDto payload)
        {
            await BaseCreateAsync(payload);
        }

        public async Task EditProvinceAsync(ProvinceEditDto payload)
        {
            await BaseEditAsync(payload.Id, payload);
        }

        public async Task DeleteProvinceAsync(string id)
        {
            await BaseDeleteAsync(id);
        }

        #region Abstract Implementation
        protected override Province CreateNewModel(ProvinceCreateDto payload)
        {
            Province province = new()
            {
                Name = payload.Name,
                Code = payload.Code,
                TimeZone = payload.TimeZone
            };

            return province;
        }

        protected override DbSet<Province> GetAppDbSet()
        {
            return dbContext.Provinces;
        }

        protected override void SetModelValue(Province model, ProvinceEditDto payload)
        {
            model.Name = payload.Name;
            model.Code = payload.Code;
        }

        protected override IQueryable<Province> SetQueryable()
        {
            return dbContext.Provinces;
        }

        protected override void ValidateCreate(Province model)
        {
            if (dbContext.Provinces.Any(a => a.Code == model.Code))
            {
                throw new Exception("Province Already Exist!");
            }
        }

        protected override void ValidateDelete(Province model)
        {

        }

        protected override void ValidateEdit(Province model)
        {
            if (dbContext.Provinces.Any(a => a.Code == model.Code && a.Id != model.Id))
            {
                throw new Exception("Province Already Exist!");
            }
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(Province.Name);
        }

        protected override ProvinceDto MappingToResultCrud(Province model)
        {
            return base.MappingToResult(model);
        }
        #endregion
    }
}
