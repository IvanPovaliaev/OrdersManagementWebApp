using OrdersManagement.Application.Contracts;
using OrdersManagement.Application.Models;
using OrdersManagement.Domain;

namespace OrdersManagement.Application.Requests.Orders.Commands.AddOrder
{
    /// <summary>
    /// Represents a command to add a new order.
    /// </summary>
    public record AddOrderCommand(AddOrdersViewModel Order) : ICommandRequest<Result<OrderViewModel>>;
}
