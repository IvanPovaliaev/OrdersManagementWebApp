using Microsoft.EntityFrameworkCore;
using OrdersManagement.Domain;
using OrdersManagement.Domain.Contracts;
using OrdersManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrdersManagement.Infrastructure.Persistence.Repositories
{
    internal class OrdersRepository : IOrdersRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OrdersRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _databaseContext.Orders.AsNoTracking()
                                                .ToListAsync();
        }

        public Task<Result<Order>> AddAsync(Order order)
        {
            throw new System.NotImplementedException();
        }
    }
}
