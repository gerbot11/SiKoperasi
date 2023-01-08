using AutoMapper;
using SiKoperasi.Core.Common;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.DataAccess.Models.Commons;

namespace SiKoperasi.Worker.Common
{
    public class WorkerSettingService : BaseSimpleService<AppDbContext>
    {
        public WorkerSettingService(AppDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        public WorkerSetting GetWorkerSettingByCode(string code)
        {
            return dbContext.WorkerSettings.Single(a => a.Code == code);
        }
    }
}
