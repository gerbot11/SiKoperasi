using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Dto.Common;
using SiKoperasi.AppService.Dto.Shu;
using SiKoperasi.Core.Common;
using SiKoperasi.Core.Data;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Shu;

namespace SiKoperasi.AppService.Services.Shu
{
    public class ShuService : BaseCrudService<ShuAllocation, ShuCreateDto, ShuEditDto, ShuDto, AppDbContext>, IShuService
    {
        private readonly IMasterSequenceService masterSequenceService;
        public ShuService(AppDbContext dbContext, IMapper mapper, IMasterSequenceService masterSequenceService, ILogger<ShuAllocation> logger) : base(dbContext, mapper, logger)
        {
            this.masterSequenceService = masterSequenceService;
        }

        public async Task<ShuDto> GetShuByIdAsync(string id)
        {
            return await BaseGetByIdAsync(id);
        }

        public async Task<PagingModel<ShuDto>> GetShuPagingAsync(QueryParamDto queryParam)
        {
            return await BaseGetPagingDataDtoAsync(queryParam);
        }

        public async Task<ShuDto> CreateShuAsync(ShuCreateDto payload)
        {
            return await BaseCreateAsync(payload);
        }

        public async Task<ShuDto> EditShuAsync(ShuEditDto payload)
        {
            return await BaseEditAsync(payload.Id, payload);
        }

        public async Task DeleteShuAsync(string id)
        {
            await BaseSafeDeleteAsync(id);
        }

        #region Abstract Impl
        protected override ShuAllocation CreateNewModel(ShuCreateDto payload)
        {
            ShuAllocation shuAllocation = mapper.Map<ShuAllocation>(payload);
            shuAllocation.IsActive = true;
            return shuAllocation;
        }

        protected override DbSet<ShuAllocation> GetAppDbSet()
        {
            return dbContext.ShuAllocations;
        }

        protected override ShuDto MappingToResultCrud(ShuAllocation model)
        {
            return base.MappingToResult(model);
        }

        protected override string SetDefaultOrderField()
        {
            return nameof(ShuAllocation.ShuName);
        }

        protected override void SetModelValue(ShuAllocation model, ShuEditDto payload)
        {
            model.ShuName = payload.ShuName;
            model.AllocationAmt = payload.AllocationAmt;
            model.Descr = payload.Descr;
            model.IsExpense = payload.IsExpense;
        }

        protected override IQueryable<ShuAllocation> SetQueryable()
        {
            return GetAppDbSet().Where(a => a.IsActive);
        }

        protected override void ValidateCreate(ShuAllocation model)
        {
            if (dbContext.ShuAllocations.Any(a => a.ShuName.Trim().ToLower() == model.ShuName.Trim().ToLower()))
                throw new Exception($"Duplicate name '{model.ShuName}'");
        }

        protected override void ValidateDelete(ShuAllocation model)
        {
            return;
        }

        protected override void ValidateEdit(ShuAllocation model)
        {
            if (dbContext.ShuAllocations.Any(a => a.ShuName.Trim().ToLower() == model.ShuName.Trim().ToLower() && a.Id != model.Id))
                throw new Exception($"Duplicate name '{model.ShuName}'");
        }
        #endregion
    }
}
