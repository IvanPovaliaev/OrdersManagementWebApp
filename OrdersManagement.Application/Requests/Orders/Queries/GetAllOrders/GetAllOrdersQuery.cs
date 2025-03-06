using OrdersManagement.Application.Contracts;
using OrdersManagement.Application.Models;
using System.Collections.Generic;

namespace OrdersManagement.Application.Requests.Orders.Queries.GetAllOrders
{
    /// <summary>
    /// Represents a query to retrieve all orders.
    /// </summary>
    public record class GetAllOrdersQuery : IQueryRequest<IEnumerable<OrderViewModel>>;
}
