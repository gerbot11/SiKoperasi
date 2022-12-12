using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Services.Loans;
using SiKoperasi.AppService.Services.Master;
using SiKoperasi.AppService.Services.Members;
using SiKoperasi.AppService.Util;
using SiKoperasi.DataAccess.Dao;

namespace SiKoperasi.Web.Common
{
    public static class DependencyConfig
    {
        public static void AddService(this IServiceCollection service, string? constring)
        {
            AddServiceScoped(service);
            AddAutoMapper(service);

            service.AddSingleton<ProblemDetailsFactory, CommonProblemDetailsFactory>();

            service.AddDbContext<AppDbContext>(op => op.UseSqlServer(constring));
        }

        private static void AddServiceScoped(IServiceCollection service)
        {
            service.AddScoped<IProvinceService, ProvinceService>();
            service.AddScoped<IDistrictService, DistrictService>();
            service.AddScoped<IMasterSequenceService, MasterSequenceService>();
            service.AddScoped<ISubDistrictService, SubDistrictService>();
            service.AddScoped<ICityService, CityService>();

            service.AddScoped<IJobService, JobService>();
            service.AddScoped<IAddressService, AddressService>();
            service.AddScoped<IMemberService, MemberService>();

            service.AddScoped<ILoanService, LoanService>();
        }

        private static void AddAutoMapper(IServiceCollection service)
        {
            service.AddAutoMapper(typeof(AutoMapperConfig));
            //service.AddAutoMapper(typeof(MemberService));
        }
    }
}
