using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Saving;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Savings;

namespace SiKoperasi.AppService.Services.Savings
{
    public class RefSavingService : BaseCrudService<RefSavingType, RefSavingTypeCreateDto, RefSavingTypeEditDto, RefSavingTypeDto, AppDbContext>, IRefSavingService
    {
        public RefSavingService(AppDbContext dbContext, IMapper mapper, ILogger<RefSavingType> logger) : base(dbContext, mapper, logger)
        {
        }

        public async Task<RefSavingTypeDto> CreateSavingTypeAsync(RefSavingTypeCreateDto payload) => await BaseCreateAsync(payload);
        public async Task<RefSavingTypeDto> EditSavingTypeAsync(RefSavingTypeEditDto payload) => await BaseEditAsync(payload.Id, payload);
        public async Task DeleteSavingTypeAsync(string id) => await BaseSafeDeleteAsync(id);
        public async Task<PagingModel<RefSavingTypeDto>> GetSavingTypePagingAsync(QueryParamDto queryParam) => await BaseGetPagingDataDtoAsync(queryParam);
        public async Task<RefSavingTypeDto> GetSavingTypeById(string id) => await BaseGetByIdAsync(id);

        protected override RefSavingType CreateNewModel(RefSavingTypeCreateDto payload)
        {
            RefSavingType type = mapper.Map<RefSavingType>(payload);
            type.IsActive = true;
            return type;
        }

        protected override DbSet<RefSavingType> GetAppDbSet()
        {
            return dbContext.RefSavingTypes;
        }

        protected override RefSavingTypeDto MappingToResultCrud(RefSavingType model)
        {
            return base.MappingToResult(model);
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(RefSavingType.SavingName);
        }

        protected override void SetModelValue(RefSavingType model, RefSavingTypeEditDto payload)
        {
            model.SavingRate = payload.SavingRate;
            model.SavingName = payload.SavingName;
            model.CutAmount = payload.CutAmount;
            model.IsMandatory = payload.IsMandatory;
            model.IsWithdrawal = payload.IsWithdrawal;
        }

        protected override IQueryable<RefSavingType> SetQueryable()
        {
            return GetAppDbSet().Where(a => a.IsActive);
        }

        protected override void ValidateCreate(RefSavingType model)
        {
            if (dbContext.RefSavingTypes.Any(a => a.SavingName.ToLower() == model.SavingName.ToLower()))
                throw new Exception("Duplicate Saving Type Name");
        }

        protected override void ValidateDelete(RefSavingType model)
        {
            return;
        }

        protected override void ValidateEdit(RefSavingType model)
        {
            if (dbContext.RefSavingTypes.Any(a => a.SavingName.ToLower() == model.SavingName.ToLower() && a.Id != model.Id))
                throw new Exception("Duplicate Saving Type Name");
        }
    }
}
