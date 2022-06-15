using System;
using System.Threading.Tasks;
using ApplicationServices.Implementsion.Common;
using ApplicationServices.Interfaces.Order;
using ApplicationServices.Interfaces.Order.Dtos;
using AutoMapper;
using Entities;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Implementsion.OrderServices
{
	public class ReadOnlyOrderService : ReadOnlyEntityService<Order, OrderDto>, IReadOnlyOrderService
	{
		public ReadOnlyOrderService(IReadOnlyDbContext readOnlyDbContext, IMapper mapper) : base(readOnlyDbContext, mapper)
		{
		}

	}
}