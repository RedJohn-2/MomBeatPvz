using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MomBeatPvz.Api.Extentions;
using MomBeatPvz.Infrastructure.Auth;
using MomBeatPvz.Persistence;
using MomBeatPvz.Persistence.Mapping;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(ToDaoMappingProfile).Assembly);

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database")));

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

builder.Services.Configure<HashOptions>(builder.Configuration.GetSection(nameof(HashOptions)));

builder.Services.AddUnitOfWork();
builder.Services.AddUserServices();
builder.Services.AddHeroServices();
builder.Services.AddTierListServices();

builder.Services.AddAuthenticationServices(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    // Конфигурация Swagger
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    // Добавляем JWT авторизацию
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Введите 'Bearer' [пробел] и токен",
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
        p.WithOrigins("http://localhost:5173");
        p.AllowAnyHeader();
        p.AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandling();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
