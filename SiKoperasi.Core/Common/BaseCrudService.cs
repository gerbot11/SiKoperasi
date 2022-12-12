using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.Core.Data;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;

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

        protected virtual async Task<TResult> GetByIdAsync(string id)
        {
            TModel? result = await GetModelByIdAsync(id);
            return MappingToResult(result);
        }

        protected virtual async Task<TModel> GetModelByIdAsync(string id)
        {
            TModel? result = await GetAppDbSet().FindAsync(id);

            if (result is null)
                throw new Exception("Data Not Found!");

            return result;
        }

        protected virtual TModel GetModelById(string id)
        {
            TModel? result = GetAppDbSet().Find(id);

            if (result is null)
                throw new Exception("Data Not Found!");

            return result;
        }

        protected virtual async Task<PagingModel<TModel>> GetPagingDataAsync(IQueryParam queryParam)
        {
            queryParam.OrderBy ??= SetDefaultOrderField();
            queryParam.OrderBehavior ??= Enums.OrderBehaviour.Asc;

            return await PagingModel<TModel>.CreateAsync(SetQueryable(), queryParam);
        }

        protected virtual async Task<PagingModel<TResult>> GetPagingDataDtoAsync(IQueryParam queryParam)
        {
            queryParam.OrderBy ??= SetDefaultOrderField();
            queryParam.OrderBehavior ??= Enums.OrderBehaviour.Asc;

            return await PagingModel<TModel>.CreateDtoPagingAsync(SetQueryable(), queryParam, MappingToResult);
        }

        protected virtual async Task<TResult> BaseCreateAsync(TPayload payload)
        {
            TModel model = CreateNewModel(payload);
            ValidateCreate(model);
            dbContext.Add(model);
            await dbContext.SaveChangesAsync();

            return MappingToResult(model);
        }

        protected virtual async Task<TResult> BaseEditAsync(string id, TPayloadEdit payload)
        {
            TModel modeledit = await GetModelByIdAsync(id);
            SetModelValue(modeledit, payload);
            ValidateEdit(modeledit);
            dbContext.Update(modeledit);
            await dbContext.SaveChangesAsync();

            return MappingToResult(modeledit);
        }

        protected virtual async Task BaseDeleteAsync(string id)
        {
            TModel model = await GetModelByIdAsync(id);
            ValidateDelete(model);
            dbContext.Remove(model);
            await dbContext.SaveChangesAsync();
        }

        protected virtual TResult MappingToResult(TModel model)
        {
            return mapper.Map<TResult>(model);
        }

        protected abstract TModel CreateNewModel(TPayload payload);
        protected abstract DbSet<TModel> GetAppDbSet();
        protected abstract IQueryable<TModel> SetQueryable();
        protected abstract void ValidateDelete(TModel model);
        protected abstract void ValidateEdit(TModel model);
        protected abstract void ValidateCreate(TModel model);
        protected abstract void SetModelValue(TModel model, TPayloadEdit payload);
        protected abstract string SetDefaultOrderField();
    }
}
