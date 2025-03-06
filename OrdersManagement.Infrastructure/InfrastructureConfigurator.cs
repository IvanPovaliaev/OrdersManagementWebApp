using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdersManagement.Application.Extensions;
using OrdersManagement.Domain.Contracts;
using OrdersManagement.Infrastructure.Persistence;
using OrdersManagement.Infrastructure.Persistence.Repositories;
using OrdersManagement.Infrastructure.Persistence.UnitOfWork;

namespace OrdersManagement.Infrastructure
{
    public static class InfrastructureConfigurator
    {
        /// <summary>
        /// Extension method to add infrastructure services to the dependency injection container
        /// </summary>
        /// <param name="services">Current service collection</param>
        /// <param name="configuration">Current service configuration</param>
        /// <returns>Current service collection with new Infrastructure services</returns>
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("OrdersManagementApp.Database")!
                                          .SetEnvironmentVariables();
            services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connection), ServiceLifetime.Scoped);

            services.AddScoped<IOrdersRepository, OrdersRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
