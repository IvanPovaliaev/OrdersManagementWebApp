using AutoMapper;
using MediatR;
using OrdersManagement.Application.Models;
using OrdersManagement.Domain;
using OrdersManagement.Domain.Contracts;
using OrdersManagement.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersManagement.Application.Requests.Orders.Commands.AddOrder
{
    /// <summary>
    /// Handles the <see cref="AddOrderCommand"/> to add a new order.
    /// </summary>
    /// <returns>Result container holding either the created <see cref="OrderViewModel"/> on success or error information</returns>
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, Result<OrderViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<OrderViewModel>> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            var dbOrder = _mapper.Map<Order>(request.Order);

            var result = await _unitOfWork.OrdersRepository.AddAsync(dbOrder);

            if (!result.IsSuccess)
            {
                return new();
            }

            var orderVM = _mapper.Map<OrderViewModel>(result.Value);

            return new(orderVM);
        }
    }
}
