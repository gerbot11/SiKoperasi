using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SiKoperasi.AppService.Contract;
using SiKoperasi.Worker.Common;

namespace SiKoperasi.Worker.Workers
{
    public class OnDueNotifyWorker : BaseWorker<OnDueNotifyWorker>
    {
        private const string WORKER_SETTING_CODE = "ONDUE_WORKER";

        public OnDueNotifyWorker(IServiceProvider serviceProvider, ILogger<OnDueNotifyWorker> logger, string code = WORKER_SETTING_CODE) : base(serviceProvider, logger, code)
        {
        }

        public async void RunProccess(object? state)
        {
            logger.LogInformation("Starting OnDueNotifyWorker At : " + DateTime.Now);
            using IServiceScope scope = serviceProvider.CreateScope();
            var loanSvc = scope.ServiceProvider.GetRequiredService<ILoanService>();
            await loanSvc.CheckOnDueLoanAsync();
            logger.LogInformation("Finish Run OnDueNotifyWorker At : " + DateTime.Now);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            _timer = new(RunProccess, null, TimeDue, TimePeriod != null ? TimePeriod.Value : TimeSpan.FromDays(1));
            return Task.CompletedTask;
        }
    }
}
