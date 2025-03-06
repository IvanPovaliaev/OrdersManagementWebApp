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

        public async Task<Result<Order>> AddAsync(Order order)
        {
            try
            {
                await _databaseContext.Orders.AddAsync(order);
                return new()
                {
                    IsSuccess = true,
                    Value = order
                };
            }
            catch (Exception)
            {
                return new();
            }
        }
    }
}
