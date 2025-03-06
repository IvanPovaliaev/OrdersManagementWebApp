using OrdersManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Result = OrdersManagement.Domain.Result<OrdersManagement.Domain.Entities.Order>;

namespace OrdersManagement.Domain.Contracts
{
    /// <summary>
    /// Interface for interacting with the orders repository.
    /// </summary>
    public interface IOrdersRepository
    {
        /// <summary>
        /// Retrieves all orders.
        /// </summary>
        /// <returns>A collection of all orders;</returns>
        public Task<List<Order>> GetAllAsync();

        /// <summary>
        /// Retrieves a specific order by its unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the order.</param>
        /// <returns>A <see cref="Result{Order}"/> containing the order if found, otherwise indicates failure.</returns>
        public Task<Result> GetAsync(Guid id);

        /// <summary>
        /// Adds a new order to the repository.
        /// </summary>
        /// <param name="order">The order to be added.</param>
        /// <returns>A <see cref="Result{Order}"/> indicating the success or failure of the operation.</returns>
        public Task<Result> AddAsync(Order order);

    }
}
