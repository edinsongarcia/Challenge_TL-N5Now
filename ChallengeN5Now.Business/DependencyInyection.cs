using Microsoft.Extensions.DependencyInjection;

namespace ChallengeN5Now.Business
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            var assembly = typeof(DependencyInyection).Assembly;

            services.AddMediatR(configuration =>
                configuration.RegisterServicesFromAssembly(assembly));

            services.AddAutoMapper(typeof(DependencyInyection));

            return services;
        }
    }

}
