using ChallengeN5Now.Data.Interfaces;
using ChallengeN5Now.Data.Repositories;
using ChallengeN5Now.Services.Interfaces;
using ChallengeN5Now.Services.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChallengeN5Now.Services
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
        {

            services
                .AddTransient<IUnitOfWork, UnitOfWork>()
                .AddTransient<IEmployeesService, EmployeeService>()
                .AddTransient<IPermissionService, PermissionService>()
                .AddTransient<IPermissionTypeService, PermissionTypeService>();

            var kafkaServer = Environment.GetEnvironmentVariable("KAFKA_SERVER");
            kafkaServer ??= configuration.GetSection("KAFKA_SERVER").Value;
            services.AddSingleton<IKafka>(new KafkaProducer(kafkaServer));

            var elesticsearchServer = Environment.GetEnvironmentVariable("ELASTICSEARCH_SERVER");
            elesticsearchServer ??= configuration.GetSection("ELASTICSEARCH_SERVER").Value;
            services.AddSingleton<IElasticsearchService>(new ElasticsearchService(elesticsearchServer));

            return services;
        }
    }
}
