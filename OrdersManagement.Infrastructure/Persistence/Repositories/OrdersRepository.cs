using Microsoft.EntityFrameworkCore;
using OrdersManagement.Domain;
using OrdersManagement.Domain.Contracts;
using OrdersManagement.Domain.Entities;
using System;
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

        public async Task<Result<Order>> GetAsync(Guid id)
        {
            var order = await _databaseContext.Orders.AsNoTracking()
                                                     .FirstOrDefaultAsync(ord => ord.Id == id);

            if (order is null)
            {
                return new();
            }

            return new(order);
        }

        public async Task<Result<Order>> AddAsync(Order order)
        {
            try
            {
                await _databaseContext.Orders.AddAsync(order);
                return new(order);
            }
            catch (Exception)
            {
                return new();
            }
        }
    }
}
