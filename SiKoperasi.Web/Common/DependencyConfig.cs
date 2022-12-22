using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Services.Common;
using SiKoperasi.AppService.Services.Loans;
using SiKoperasi.AppService.Services.Master;
using SiKoperasi.AppService.Services.Members;
using SiKoperasi.AppService.Services.Savings;
using SiKoperasi.AppService.Util.AutoMapperConfig;
using SiKoperasi.DataAccess.Dao;

namespace SiKoperasi.Web.Common
{
    public static class DependencyConfig
    {
        public static void AddService(this IServiceCollection service, string? constring)
        {
            AddServiceScoped(service);
            AddAutoMapper(service);
            //AddGoogleAuth(service);

            service.AddSingleton<ProblemDetailsFactory, CommonProblemDetailsFactory>();

            service.AddDbContext<AppDbContext>(op => op.UseSqlServer(constring));

            service.AddTransient<IFileUploadExtService, FileUploadExtService>();
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

            service.AddScoped<ISavingService, SavingService>();

            service.AddScoped<ILoanService, LoanService>();
            service.AddScoped<IInstalmentService, InstalmentService>();

            service.AddScoped<IRefService, RefService>();
        }

        private static void AddAutoMapper(IServiceCollection service)
        {
            service.AddAutoMapper(typeof(AutoMapperConfig));
            service.AddAutoMapper(typeof(LoanAutoMapperConfig));
            service.AddAutoMapper(typeof(RefAutoMapperConfig));
            service.AddAutoMapper(typeof(MemberAutoMapperConfig));
            service.AddAutoMapper(typeof(SavingAutoMapperConfig));
        }

        private static void AddGoogleAuth(IServiceCollection services)
        {
            services.AddAuthentication().AddGoogle(options => {
                options.ClientId = "1001136522800-nme6vn9vbuvehraqn0mt9an7pre3em7m.apps.googleusercontent.com";
                options.ClientSecret = "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";
            });
        }
    }
}
