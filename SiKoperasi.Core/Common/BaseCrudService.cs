using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.Core.Data;
using SiKoperasi.Core.Exceptions;
using System.Reflection;

namespace SiKoperasi.Core.Common
{
    public abstract class BaseCrudService<TModel, TPayload, TPayloadEdit ,TResult, TDbContext>
        where TModel : BaseModel
        where TPayload : class
        where TDbContext : DbContext
        where TResult : class
    {
        protected readonly TDbContext dbContext;
        protected readonly IMapper mapper;

        public BaseCrudService(TDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected virtual async Task<TResult> BaseGetByIdAsync(string id, bool hasIncluded = false)
        {
            if (!hasIncluded)
            {
                TModel? result = await BaseGetModelByIdAsync(id);
                return MappingToResult(result);
            }

            TModel? resultIncluded = await SetQueryable().FirstOrDefaultAsync(a => a.Id == id);
            if (resultIncluded is null)
                throw new ModelNotFoundException($"{typeof(TModel).Name}");

            return MappingToResult(resultIncluded);
        }

        protected virtual async Task<TModel> BaseGetModelByIdAsync(string id)
        {
            TModel? result = await GetAppDbSet().FindAsync(id);

            if (result is null)
                throw new ModelNotFoundException($"{typeof(TModel).Name}");

            return result;
        }

        protected virtual TModel BaseGetModelById(string id)
        {
            TModel? result = GetAppDbSet().Find(id);

            if (result is null)
                throw new ModelNotFoundException($"{typeof(TModel).Name}");

            return result;
        }

        protected virtual async Task<PagingModel<TModel>> BaseGetPagingDataAsync(IQueryParam queryParam, IQueryable<TModel>? customquery = null)
        {
            queryParam.OrderBy ??= SetDefaultOrderField();
            queryParam.OrderBehavior ??= Enums.OrderBehaviour.Asc;
            customquery ??= SetQueryable();

            return await PagingModel<TModel>.CreateAsync(customquery, queryParam);
        }

        protected virtual async Task<PagingModel<TResult>> BaseGetPagingDataDtoAsync(IQueryParam queryParam, IQueryable<TModel>? customquery = null)
        {
            queryParam.OrderBy ??= SetDefaultOrderField();
            queryParam.OrderBehavior ??= Enums.OrderBehaviour.Asc;
            customquery ??= SetQueryable();

            return await PagingModel<TModel>.CreateDtoPagingAsync(customquery, queryParam, MappingToResult);
        }

        protected virtual async Task<PagingModel<TCustomResult>> BaseGetPagingCustomResultAsync<TCustomResult>(IQueryParam queryParam, IQueryable<TCustomResult> customquery)
            where TCustomResult : class
        {
            queryParam.OrderBehavior ??= Enums.OrderBehaviour.Asc;

            return await PagingModel<TCustomResult>.CreateAsync(customquery, queryParam);
        }

        protected virtual async Task<TResult> BaseCreateAsync(TPayload payload)
        {
            TModel model = CreateNewModel(payload);
            ValidateCreate(model);
            dbContext.Add(model);
            await dbContext.SaveChangesAsync();

            return MappingToResultCrud(model);
        }

        protected virtual async Task<TResult> BaseEditAsync(string id, TPayloadEdit payload)
        {
            TModel modeledit = await BaseGetModelByIdAsync(id);
            SetModelValue(modeledit, payload);
            ValidateEdit(modeledit);
            dbContext.Update(modeledit);
            await dbContext.SaveChangesAsync();

            return MappingToResultCrud(modeledit);
        }

        protected virtual async Task BaseDeleteAsync(string id)
        {
            TModel model = await BaseGetModelByIdAsync(id);
            ValidateDelete(model);
            dbContext.Remove(model);
            await dbContext.SaveChangesAsync();
        }

        protected virtual async Task BaseSafeDeleteAsync(string id)
        {
            TModel model = await BaseGetModelByIdAsync(id);
            SetSafeDeleteValue(model);
            dbContext.Update(model);
            await dbContext.SaveChangesAsync();
        }

        protected virtual TResult MappingToResult(TModel model)
        {
            return mapper.Map<TResult>(model);
        }

        protected virtual void SetSafeDeleteValue(TModel model)
        {
            Type objType = model.GetType();
            PropertyInfo? propertyInfo = objType.GetProperty("IsActive");
            if (propertyInfo is null)
                throw new Exception("Invalid Property Info for Safe Delete");

            propertyInfo.SetValue(model, false);
        }

        protected abstract TModel CreateNewModel(TPayload payload);
        protected abstract TResult MappingToResultCrud(TModel model);
        protected abstract DbSet<TModel> GetAppDbSet();
        protected abstract IQueryable<TModel> SetQueryable();
        protected abstract void ValidateDelete(TModel model);
        protected abstract void ValidateEdit(TModel model);
        protected abstract void ValidateCreate(TModel model);
        protected abstract void SetModelValue(TModel model, TPayloadEdit payload);
        protected abstract string SetDefaultOrderField();
    }
}
