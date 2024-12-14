using Microsoft.Extensions.Options;
using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Application.Operations;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Infrastructure.RecalculatePrices;

namespace MomBeatPvz.Api.BackgroundServices
{
    public class RecalculateTierListPricesBackgroundService : BackgroundService
    {
        private readonly IRecalculateTierListPricesOperation _recalculateOperation;

        private readonly RecalculatePricesOptions _recalcOpt;

        public RecalculateTierListPricesBackgroundService(
            IRecalculateTierListPricesOperation recalculateOperation, 
            IOptions<RecalculatePricesOptions> opts)
        {
            _recalculateOperation = recalculateOperation;
            _recalcOpt = opts.Value;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _recalculateOperation.Operate();

                await Task.Delay(1000 * _recalcOpt.RecalculateTimeSeconds, stoppingToken);
            }
        }

    }
}
