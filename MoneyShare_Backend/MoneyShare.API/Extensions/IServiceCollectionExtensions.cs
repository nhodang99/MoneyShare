using Microsoft.EntityFrameworkCore;
using MoneyShare.Domain.Interfaces;
using MoneyShare.Domain.Users;
using MoneyShare.Infrastructure.Repositories;
using MoneyShare.Infrastructure;
using MoneyShare.Domain.Bills;
using MoneyShare.Domain.Groups;
using MoneyShare.API.Services;

namespace MoneyShare.API.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseLazyLoadingProxies()
                    .UseSqlServer(configuration.GetConnectionString("ConnectionString"),
                        b => b.MigrationsAssembly("MoneyShare.Infrastructure"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IBillRepository, BillRepository>()
                .AddScoped<IGroupRepository, GroupRepository>()
                .AddScoped<IUserRepository, UserRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<BillsService>()
                .AddScoped<UsersService>()
                .AddScoped<GroupsService>();
        }
    }
}
