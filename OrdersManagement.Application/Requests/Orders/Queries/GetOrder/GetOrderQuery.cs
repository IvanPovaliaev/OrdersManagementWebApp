using OrdersManagement.Application.Contracts;
using OrdersManagement.Application.Models;
using OrdersManagement.Domain;
using System;

namespace OrdersManagement.Application.Requests.Orders.Queries.GetOrder
{
    public record class GetOrderQuery(Guid Id) : IQueryRequest<Result<OrderViewModel>>;
}
