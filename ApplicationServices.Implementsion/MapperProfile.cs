using ApplicationServices.Interfaces.Order.Dtos;
using ApplicationServices.Interfaces.Product.Dtos;
using AutoMapper;
using Entities;

namespace ApplicationServices.Implementsion {
	public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>().ReverseMap();
            CreateMap<ChangeOrderDto, Order>();

            CreateMap<Product, ProductDto>();
            CreateMap<ChangeProductDto, Product>();
        }
    }
}