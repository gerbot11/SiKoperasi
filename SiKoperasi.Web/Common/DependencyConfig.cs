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
using SiKoperasi.AppService.Util.AutoMapperConfig;
using SiKoperasi.AppService.Util.ConfigOptions;
using SiKoperasi.Auth.Commons;
using SiKoperasi.Auth.Models;
using SiKoperasi.Auth.Services;
using SiKoperasi.DataAccess.Dao;

namespace SiKoperasi.Web.Common
{
    public static class DependencyConfig
    {
        public static void AddService(this IServiceCollection service, ConfigurationManager configuration)
        {
            AddServiceScoped(service);
            AddAutoMapper(service);
            //AddGoogleAuth(service);

            service.AddSingleton<ProblemDetailsFactory, CommonProblemDetailsFactory>();
            service.AddSingleton<IJwtTokenGeneratorService, JwtTokenGeneratorService>();

            service.AddDbContext<AppDbContext>(op => op.UseSqlServer(configuration.GetConnectionString("Assasins13")));

            service.AddTransient<IFileUploadExtService, FileUploadExtService>();

            service.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SECTION_NAME));
            service.Configure<GoogleDriveSetting>(configuration.GetSection(GoogleDriveSetting.SECTION_NAME));

            service.AddScoped<IPasswordHasher<User>, PasswordHasher>();
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

            service.AddScoped<ICashBankService, CashBankService>();
        }

        private static void AddAutoMapper(IServiceCollection service)
        {
            service.AddAutoMapper(typeof(AutoMapperConfig));
            service.AddAutoMapper(typeof(LoanAutoMapperConfig));
            service.AddAutoMapper(typeof(RefAutoMapperConfig));
            service.AddAutoMapper(typeof(MemberAutoMapperConfig));
            service.AddAutoMapper(typeof(SavingAutoMapperConfig));
        }
    }
}
