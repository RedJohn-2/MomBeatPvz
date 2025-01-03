using Microsoft.EntityFrameworkCore;
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
builder.Services.AddSwaggerGen();

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
