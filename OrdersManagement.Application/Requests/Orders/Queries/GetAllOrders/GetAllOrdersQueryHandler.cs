using AutoMapper;
using MediatR;
using OrdersManagement.Application.Models;
using OrdersManagement.Domain.Contracts;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace OrdersManagement.Application.Requests.Orders.Queries.GetAllOrders
{
    /// <summary>
    /// Handles the <see cref="GetAllOrdersQuery"/> to retrieve all orders from the system.
    /// </summary>
    public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, IEnumerable<OrderViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllOrdersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderViewModel>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var dbOrders = await _unitOfWork.OrdersRepository.GetAllAsync();
            return dbOrders.Select(_mapper.Map<OrderViewModel>);
        }
    }
}
