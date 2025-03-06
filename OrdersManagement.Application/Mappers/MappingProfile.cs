using AutoMapper;
using OrdersManagement.Application.Models;
using OrdersManagement.Domain.Entities;

namespace OrdersManagement.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<AddOrdersViewModel, Order>();
        }
    }
}
