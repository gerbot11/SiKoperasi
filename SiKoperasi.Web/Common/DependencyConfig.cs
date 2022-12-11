using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Services.Master;
using SiKoperasi.DataAccess.Dao;

namespace SiKoperasi.Web.Common
{
    public static class DependencyConfig
    {
        public static void AddService(this IServiceCollection service, string constring)
        {
            service.AddScoped<IProvinceService, ProvinceService>();

            service.AddDbContext<AppDbContext>(op => op.UseSqlServer(constring));

            service.AddAutoMapper(typeof(ProvinceService));
        }
    }
}
