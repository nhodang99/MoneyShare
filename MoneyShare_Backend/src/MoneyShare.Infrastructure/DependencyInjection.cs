#region

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.JsonWebTokens;
using MoneyShare.Application.Interfaces.Authentication;
using MoneyShare.Application.Models;
using MoneyShare.Domain;
using MoneyShare.Infrastructure.Authentication;
using MoneyShare.Infrastructure.Authentication.Options;
using MoneyShare.Infrastructure.Database;

#endregion

namespace MoneyShare.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDatabase(configuration)
            .AddUnitOfWork()
            .AddAuthenticationInternal(configuration)
            .AddAuthorizationInternal();
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options
                .UseLazyLoadingProxies()
                .UseNpgsql(configuration.GetConnectionString("ConnectionString"), npgsqlOptions =>
                    npgsqlOptions.MigrationsHistoryTable(HistoryRepository.DefaultTableName, "default"));
        });
        return services;
    }

    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        return services.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static IServiceCollection AddAuthenticationInternal(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AppDbContext>();

        // services.AddScoped<SignInManager<ApplicationUser>>();

        services.AddScoped<IIdentityService, IdentityService>();
        services.AddAutoMapper(config => { config.AddProfile(new IdentityProfile()); });

        // Avoid JwtRegisteredClaimNames.Sub auto mapping to ClaimTypes.NameIdentifier
        JsonWebTokenHandler.DefaultInboundClaimTypeMap.Clear();

        services
            .AddHttpContextAccessor()
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer();

        services
            .ConfigureOptions<JwtOptionsSetup>()
            .ConfigureOptions<JwtBearerOptionsSetup>();

        services.AddSingleton<IJwtProvider, JwtProvider>();

        return services;
    }

    private static IServiceCollection AddAuthorizationInternal(this IServiceCollection services)
    {
        services.AddAuthorization();

        return services;
    }
}