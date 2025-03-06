using AutoMapper;
using OrdersManagement.Application.Models;
using OrdersManagement.Domain.Entities;
using System;

namespace OrdersManagement.Application.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Order, OrderViewModel>().ReverseMap();
            CreateMap<Order, ShortOrderInfoViewModel>().ReverseMap();

            CreateMap<AddOrdersViewModel, Order>()
                .ForMember(destination => destination.ExpirationDate,
                            option => option.MapFrom(source => DateTime.SpecifyKind(source.ExpirationDate, DateTimeKind.Utc)));
        }
    }
}
