using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdersManagement.Application.Behaviors;
using OrdersManagement.Application.Mappers;
using System.Reflection;

namespace OrdersManagement.Application
{
    public static class ApplicationConfigurator
    {
        /// <summary>
        /// Extension method to add application services to the dependency injection container
        /// </summary>
        /// <param name="services">Current service collection</param>
        /// <param name="configuration">Current service configuration</param>
        /// <returns>Current service collection with new Application services</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(UnitOfWorkBehavior<,>));

            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }
    }
}
