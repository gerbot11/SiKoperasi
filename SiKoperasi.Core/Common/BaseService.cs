using Microsoft.EntityFrameworkCore;

namespace SiKoperasi.Core.Common
{
    public abstract class BaseService<TModel, TResult, TDbContext>
        where TDbContext : DbContext
        where TModel : class
        where TResult : class
    {
        protected TDbContext dbContext;
        public BaseService(TDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        protected virtual async Task<TResult> GetResultByIdAsync(string id)
        {
            TModel? model = await GetAppDbSet().FindAsync(id);
            if (model is null)
                throw new Exception("Data Not Found!");

            TResult result = MappingResultValue(model);
            return result;
        }

        protected virtual async Task<IEnumerable<TResult>> GetResultsListAsync()
        {
            IQueryable<TModel> modelsRes = GetAppDbSet();
            if (!modelsRes.Any())
                return Enumerable.Empty<TResult>();

            IEnumerable<TResult> result = MappingResultListValue(modelsRes);
            return result;
        }

        protected abstract DbSet<TModel> GetAppDbSet();
        protected abstract TResult MappingResultValue(TModel model);
        protected abstract IEnumerable<TResult> MappingResultListValue(IQueryable<TModel> models);
    }
}
