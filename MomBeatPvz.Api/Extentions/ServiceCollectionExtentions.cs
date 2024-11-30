using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using MomBeatPvz.Application.Interfaces;
using MomBeatPvz.Application.Services;
using MomBeatPvz.Core.Store;
using MomBeatPvz.Infrastructure.Auth;
using System.Text;

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

        public static IServiceCollection AddAuthenticationServices(this IServiceCollection services,
           IConfiguration configuration)
        {
            var jwtOpt = configuration.GetSection(nameof(JwtOptions)).Get<JwtOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
                {
                    opt.TokenValidationParameters = new()
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOpt!.SecretKey))
                    };

                    opt.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies[jwtOpt.CookieAccessToken];

                            return Task.CompletedTask;
                        }
                    };
                });

            return services;
        }
    }
}
