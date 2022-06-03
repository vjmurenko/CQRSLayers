using ApplicationServices.Interfaces;
using AutoMapper;
using Entities;

namespace ApplicationServices.Implementsion
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<ChangeOrderDto, Order>();

        }
    }
}