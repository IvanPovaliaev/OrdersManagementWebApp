using OrdersManagement.Application.Contracts;
using OrdersManagement.Application.Models;
using System.Collections.Generic;

namespace OrdersManagement.Application.Requests.Orders.Queries.GetAllOrders
{
    /// <summary>
    /// Represents a query to retrieve all orders.
    /// </summary>
    /// <returns>A collection of <see cref="ShortOrderInfoViewModel"/>.</returns>
    public record class GetAllOrdersQuery : IQueryRequest<IEnumerable<ShortOrderInfoViewModel>>;
}
