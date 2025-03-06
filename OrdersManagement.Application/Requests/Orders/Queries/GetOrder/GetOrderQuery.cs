using OrdersManagement.Application.Contracts;
using OrdersManagement.Application.Models;
using OrdersManagement.Domain;
using System;

namespace OrdersManagement.Application.Requests.Orders.Queries.GetOrder
{
    /// <summary>
    /// Represents a query to retrieve a specific order by its unique identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the order to be retrieved.</param>
    /// <returns>A <see cref="Result{OrderViewModel}"/> if order found, or error information if the order is not found.</returns>
    public record class GetOrderQuery(Guid Id) : IQueryRequest<Result<OrderViewModel>>;
}
