using AutoMapper;

namespace SiKoperasi.Core.Common
{
    public abstract class BaseSimpleService<TDbContext>
    {
        protected TDbContext dbContext;
        protected IMapper mapper;
        public BaseSimpleService(TDbContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
    }
}
