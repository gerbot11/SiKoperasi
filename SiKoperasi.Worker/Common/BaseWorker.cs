using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SiKoperasi.DataAccess.Models.Commons;
using System.Globalization;

namespace SiKoperasi.Worker.Common
{
    public abstract class BaseWorker<TWorker> : BackgroundService
    {
        private const string SEC_INTERVAL = "SECOND";
        private const string MINUTE_INTERVAL = "MINUTE";
        private const string HOUR_INTERVAL = "HOUR";
        private const string DAY_INTERVAL = "DAY";

        protected WorkerSetting workerSetting = new();
        protected Timer? _timer;
        protected readonly ILogger<TWorker> logger;
        protected IServiceProvider serviceProvider;

        protected TimeSpan? TimePeriod { get; private set; }
        protected TimeSpan TimeDue { get; private set; }

        public BaseWorker(IServiceProvider serviceProvider, ILogger<TWorker> logger, string code)
        {
            this.logger = logger;
            this.serviceProvider = serviceProvider;
            SetWorkerSetting(code);
        }

        protected void SetWorkerSetting(string settingCode)
        {
            using IServiceScope scope = serviceProvider.CreateScope();
            var settingService = scope.ServiceProvider.GetRequiredService<WorkerSettingService>();

            workerSetting = settingService.GetWorkerSettingByCode(settingCode);
            TimePeriod = workerSetting.RunningInterval switch
            {
                SEC_INTERVAL => TimeSpan.FromSeconds(workerSetting.IntervalValue),
                MINUTE_INTERVAL => TimeSpan.FromMinutes(workerSetting.IntervalValue),
                HOUR_INTERVAL => TimeSpan.FromHours(workerSetting.IntervalValue),
                DAY_INTERVAL => TimeSpan.FromDays(workerSetting.IntervalValue),
                _ => null
            };

            DateTime time = DateTime.ParseExact(workerSetting.StartTime, "HH:mm", CultureInfo.InvariantCulture);
            DateTime timeNow = DateTime.Now;
            if (time < timeNow)
                time = time.AddDays(1);

            TimeSpan ts = time - timeNow;
            double tick = ts.TotalMilliseconds;
            TimeDue = TimeSpan.FromMilliseconds(tick);

            logger.LogInformation($"\n" +
                $"Worker Name : {workerSetting.Name}\n" +
                $"Running Every : {workerSetting.IntervalValue} {workerSetting.RunningInterval} \n" +
                $"Running On : {workerSetting.StartTime} \n" +
                $"Time Of Day : {time.TimeOfDay} \n" +
                $"TimeDue : {TimeDue} \n" +
                $"Time Period : {TimePeriod}");
        }
    }
}
