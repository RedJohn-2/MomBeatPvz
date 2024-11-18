using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Application.Services;
using MomBeatPvz.Core.Store;

namespace MomBeatPvz.Api.Extentions
{
    public static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddHeroServices(this IServiceCollection services)
        {
            //services.AddScoped<IHeroStore, HeroService>();
            services.AddScoped<IHeroService, HeroService>();
            return services;
        }

        public static IServiceCollection AddTierListServices(this IServiceCollection services)
        {
            services.AddScoped<ITierListService, TierListService>();

            services.AddScoped<ITierListSolutionService, TierListSolutionService>();

            return services;
        }
    }
}
