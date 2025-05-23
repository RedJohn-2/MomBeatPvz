using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MomBeatPvz.Api.BackgroundServices;
using MomBeatPvz.Api.Extentions;
using MomBeatPvz.Api.Mapping;
using MomBeatPvz.Infrastructure.Auth;
using MomBeatPvz.Infrastructure.Cache;
using MomBeatPvz.Infrastructure.RecalculatePrices;
using MomBeatPvz.Persistence;
using MomBeatPvz.Persistence.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddAutoMapper(typeof(ToDaoMappingProfile).Assembly, typeof(ToDtoMappingProfile).Assembly);

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

builder.Services.AddStackExchangeRedisCache(options => 
    options.Configuration = builder.Configuration.GetConnectionString("Cache"));

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.Configure<HashOptions>(builder.Configuration.GetSection(nameof(HashOptions)));

builder.Services.Configure<RedisOptions>(builder.Configuration.GetSection(nameof(RedisOptions)));

builder.Services.Configure<RecalculatePricesOptions>(builder.Configuration.GetSection(nameof(RecalculatePricesOptions)));

builder.Services.AddCacheProvider();
builder.Services.AddUnitOfWork();
builder.Services.AddUserServices();
builder.Services.AddHeroServices();
builder.Services.AddTierListServices();
builder.Services.AddTeamServices();
builder.Services.AddMatchServices();
builder.Services.AddChampionshipServices();

builder.Services.AddAuthenticationServices(builder.Configuration);

builder.Services.AddHostedService<RecalculateTierListPricesBackgroundService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // ������������ Swagger
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // ��������� JWT �����������
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "������� �����",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
});

builder.Services.AddCors(opts =>
{
    opts.AddDefaultPolicy(p =>
    {
        p.WithOrigins("https://jplqp5-83-139-146-176.ru.tuna.am");
        p.AllowAnyHeader();
        p.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
/*if (app.Environment.IsDevelopment())
{
    
}*/

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
});

app.UseExceptionHandling();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
