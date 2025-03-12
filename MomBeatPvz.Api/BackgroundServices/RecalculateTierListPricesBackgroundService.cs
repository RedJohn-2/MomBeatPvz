using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Application.Operations;
using MomBeatPvz.Core.Model;
using MomBeatPvz.Infrastructure.RecalculatePrices;

namespace MomBeatPvz.Api.BackgroundServices
{
    public class RecalculateTierListPricesBackgroundService : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;

        private readonly RecalculatePricesOptions _recalcOpt;

        public RecalculateTierListPricesBackgroundService(
            IServiceScopeFactory serviceScopeFactory, 
            IOptions<RecalculatePricesOptions> opts)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _recalcOpt = opts.Value;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var recalculateOperation = 
                        scope.ServiceProvider.GetRequiredService<IRecalculateTierListPricesOperation>();

                    await recalculateOperation.Operate();
                }

                await Task.Delay(1000 * _recalcOpt.RecalculateTimeSeconds, stoppingToken);
            }
        }

    }
}
