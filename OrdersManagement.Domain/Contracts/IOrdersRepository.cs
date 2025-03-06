﻿using OrdersManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Result = OrdersManagement.Domain.Result<OrdersManagement.Domain.Entities.Order>;

namespace OrdersManagement.Domain.Contracts
{
    public interface IOrdersRepository
    {
        public Task<List<Order>> GetAllAsync();

        public Task<Result> GetAsync(Guid id);

        public Task<Result> AddAsync(Order order);

    }
}
