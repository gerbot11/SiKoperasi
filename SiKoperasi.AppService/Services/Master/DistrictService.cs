using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.District;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.MasterData;

namespace SiKoperasi.AppService.Services.Master
{
    public class DistrictService : BaseCrudService<District, DistrictCreateDto, DistrictEditDto, DistrictDto, AppDbContext>, IDistrictService
    {
        public DistrictService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public async Task<DistrictDto> GetDistrictAsync(string id)
        {
            return await BaseGetByIdAsync(id);
        }

        public async Task<PagingModel<DistrictDto>> GetDistrictPagingAsync(QueryParamDto queryParam)
        {
            return await BaseGetPagingDataDtoAsync(queryParam);
        }

        #region Abstract Implementation
        protected override District CreateNewModel(DistrictCreateDto payload)
        {
            return mapper.Map<District>(payload);
        }

        protected override DbSet<District> GetAppDbSet()
        {
            return dbContext.Districts;
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(District.Name);
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
