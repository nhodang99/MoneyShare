using Microsoft.Extensions.DependencyInjection;
using MoneyShare.Application.Contracts.Interfaces;
using MoneyShare.Application.Services;

namespace MoneyShare.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddScoped<IAuthenticationService, AuthenticationService>()
            .AddScoped<IBillService, BillService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IGroupService, GroupService>();
    }
}
