using ChallengeN5Now.Data.Interfaces;
using ChallengeN5Now.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeN5Now.Data
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            var assembly = typeof(DependencyInyection).Assembly.FullName;
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? configuration.GetConnectionString("sql_server");

            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(connectionString, m => m.MigrationsAssembly(assembly)));

            services
                .AddTransient<IEmployeeRepository, EmployeeRepository>()
                .AddTransient<IPermissionRepository, PermissionRepository>()
                .AddTransient<IPermissionTypeRepository, PermissionTypeRepository>();

            return services;
        }
    }

}
