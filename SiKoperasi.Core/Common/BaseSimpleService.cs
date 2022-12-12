namespace SiKoperasi.Core.Common
{
    public abstract class BaseSimpleService<TDbContext>
    {
        protected TDbContext dbContext;
        public BaseSimpleService(TDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
    }
}
