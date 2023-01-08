using Microsoft.Extensions.Logging;
using SiKoperasi.Worker.Common;

namespace SiKoperasi.Worker.Workers
{
    public class OnDuePayrollPaymentWorker : BaseWorker<OnDuePayrollPaymentWorker>
    {
        private const string WORKER_SETTING_CODE = "ONDUE_PAYROLL_PAYMENT_WORKER";
        public OnDuePayrollPaymentWorker(IServiceProvider serviceProvider, ILogger<OnDuePayrollPaymentWorker> logger, string code = WORKER_SETTING_CODE) : base(serviceProvider, logger, code)
        {
        }

        public async void RunProccess(object? state)
        {

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();
            _timer = new(RunProccess, null, TimeDue, TimePeriod.Value);
            return Task.CompletedTask;
        }
    }
}
