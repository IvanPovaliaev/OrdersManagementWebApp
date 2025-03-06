using AutoMapper;
using MediatR;
using OrdersManagement.Application.Models;
using OrdersManagement.Domain;
using OrdersManagement.Domain.Contracts;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersManagement.Application.Requests.Orders.Queries.GetOrder
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQuery, Result<OrderViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<OrderViewModel>> Handle(GetOrderQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.OrdersRepository.GetAsync(request.Id);
            if (!result.IsSuccess)
            {
                return new();
            }

            var order = _mapper.Map<OrderViewModel>(result.Value);

            return new(order);
        }
    }
}
