using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrdersManagement.Domain.Contracts;
using OrdersManagement.Infrastructure.Persistence.Repositories;

namespace OrdersManagement.Infrastructure
{
    public static class InfrastructureConfigurator
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IOrdersRepository, OrdersRepository>();
            return services;
        }
    }
}
