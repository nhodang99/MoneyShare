using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MoneyShare.Application.Contracts.Behaviors;
using MoneyShare.Application.Mapper;
using MoneyShare.Domain.Interfaces;
using MoneyShare.Domain.Services;

namespace MoneyShare.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

            config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
            config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
        });

        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

        services.AddAutoMapper(config =>
        {
            config.AddProfile(new UserProfile());
            config.AddProfile(new GroupProfile());
            config.AddProfile(new BillProfile());
        });

        services.AddScoped<IAuthenticationService, AuthenticationService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IBillService, BillService>();
        services.AddScoped<IGroupService, GroupService>();

        return services;
    }
}
