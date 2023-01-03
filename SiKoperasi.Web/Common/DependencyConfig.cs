using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SiKoperasi.AppService.Contract;
using SiKoperasi.AppService.Services.CashBanks;
using SiKoperasi.AppService.Services.Common;
using SiKoperasi.AppService.Services.Loans;
using SiKoperasi.AppService.Services.Master;
using SiKoperasi.AppService.Services.Members;
using SiKoperasi.AppService.Services.Savings;
using SiKoperasi.AppService.Services.Shu;
using SiKoperasi.AppService.Util.AutoMapperConfig;
using SiKoperasi.Auth.Commons;
using SiKoperasi.Auth.Models;
using SiKoperasi.Auth.Services;
using SiKoperasi.DataAccess.Dao;
using SiKoperasi.ExternalService.Contract;
using SiKoperasi.ExternalService.Services;
using SiKoperasi.ExternalService.Utilities;

namespace SiKoperasi.Web.Common
{
    public static class DependencyConfig
    {
        public static void AddService(this IServiceCollection service, ConfigurationManager configuration)
        {
            AddServiceScoped(service);
            AddServiceTransient(service);
            AddServiceSingleton(service);
            AddAutoMapper(service);
            AddConfigureItem(service, configuration);
            AddDbContext(service, configuration);
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
            service.AddScoped<ISavingTransactionService, SavingTransactionService>();

            service.AddScoped<ILoanService, LoanService>();
            service.AddScoped<IInstalmentService, InstalmentService>();
            service.AddScoped<ILoanPaymentService, LoanPaymentService>();

            service.AddScoped<IRefService, RefService>();

            service.AddScoped<ILoginService, LoginService>();
            service.AddScoped<IPasswordHasher<User>, PasswordHasher>();

            service.AddScoped<ICashBankService, CashBankService>();

            service.AddScoped<IShuService, ShuService>();
            service.AddScoped<IShuTrxService, ShuTrxService>();
        }

        private static void AddServiceTransient(IServiceCollection service)
        {
            service.AddTransient<IGoogleDriveService, GoogleDriveService>();
        }

        private static void AddServiceSingleton(IServiceCollection service)
        {
            service.AddSingleton<ProblemDetailsFactory, CommonProblemDetailsFactory>();
            service.AddSingleton<IJwtTokenGeneratorService, JwtTokenGeneratorService>();
        }

        private static void AddDbContext(IServiceCollection service, ConfigurationManager configuration)
        {
            service.AddDbContext<AppDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("Assasins13")));
        }

        private static void AddAutoMapper(IServiceCollection service)
        {
            service.AddAutoMapper(typeof(AutoMapperConfig));
            service.AddAutoMapper(typeof(LoanAutoMapperConfig));
            service.AddAutoMapper(typeof(RefAutoMapperConfig));
            service.AddAutoMapper(typeof(MemberAutoMapperConfig));
            service.AddAutoMapper(typeof(SavingAutoMapperConfig));
        }

        private static void AddConfigureItem(IServiceCollection service, ConfigurationManager configuration)
        {
            service.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SECTION_NAME));
            service.Configure<GoogleDriveSetting>(configuration.GetSection(GoogleDriveSetting.SECTION_NAME));
        }
    }
}
