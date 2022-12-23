using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.Core.Data;

namespace SiKoperasi.Core.Common
{
    public abstract class BaseService<TModel, TResult, TDbContext>
        where TDbContext : DbContext
        where TModel : class
        where TResult : class
    {
        protected TDbContext dbContext;
        protected IMapper mapper;
        public BaseService(TDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }

        protected virtual async Task<TResult> GetResultByIdAsync(string id)
        {
            TModel? model = await GetAppDbSet().FindAsync(id);
            if (model is null)
                throw new Exception($"{typeof(TModel).Name} Data Not Found!");

            TResult result = MappingResultValue(model);
            return result;
        }

        protected virtual async Task<TModel> GetModelByIdAsync(string id)
        {
            TModel? model = await GetAppDbSet().FindAsync(id);
            if (model is null)
                throw new Exception($"{typeof(TModel).Name} Data Not Found!");

            return model;
        }

        protected virtual IEnumerable<TResult> GetResultsListAsync()
        {
            IQueryable<TModel> modelsRes = GetAppDbSet();
            if (!modelsRes.Any())
                return Enumerable.Empty<TResult>();

            IEnumerable<TResult> result = MappingModelToResultList(modelsRes);
            return result;
        }

        protected virtual async Task<PagingModel<TResult>> GetPagingDataDtoAsync(IQueryParam queryParam, IQueryable<TModel>? customquery = null)
        {
            queryParam.OrderBy ??= SetDefaultOrderField();
            queryParam.OrderBehavior ??= Enums.OrderBehaviour.Asc;
            customquery ??= SetQueryable();

            return await PagingModel<TModel>.CreateDtoPagingAsync(customquery, queryParam, MappingResultValue);
        }

        private TResult MappingResultValue(TModel model)
        {
            return mapper.Map<TResult>(model);
        }

        private IEnumerable<TResult> MappingModelToResultList(IQueryable<TModel> source)
        {
            return mapper.Map<IQueryable<TModel>, IEnumerable<TResult>>(source);
        }

        protected abstract DbSet<TModel> GetAppDbSet();
        protected abstract IQueryable<TModel> SetQueryable();
        protected abstract string SetDefaultOrderField();
    }
}
