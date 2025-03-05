using OrdersManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Result = OrdersManagement.Domain.Result<OrdersManagement.Domain.Entities.Order>;

namespace OrdersManagement.Domain.Contracts
{
    public interface IOrdersRepository
    {
        public Task<List<Order>> GetAll();

        public Task<Result> AddAsync(Order order);
    }
}
