using System;
using System.Linq;
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
	public class OrderService : EntityService<Order, ChangeOrderDto>, IOrderService
	{
		private readonly IDbContext _dbContext;
		private readonly ICurrentUserService _currentUserService;
		private readonly IStatisticService _statisticService;

		public OrderService(IDbContext dbContext,
			IMapper mapper,
			ICurrentUserService currentUserService,
			IStatisticService statisticService) : base(dbContext, mapper)
		{
			_dbContext = dbContext;
			_currentUserService = currentUserService;
			_statisticService = statisticService;
		}

		public override async Task Update(int id, ChangeOrderDto tDto)
		{
			await _statisticService.WriteStatisticAsync("Order", tDto.Items.Select(i => i.ProductId));
			await base.Update(id, tDto);
		}

		public override Task Delete(int id)
		{
			throw new NotSupportedException();
		}

		protected override void IniializeNewEntity(Order entity)
		{
			entity.Email = _currentUserService.Email;
		}

		protected override async Task<Order> GetTrackedEntityAsync(int id)
		{
			return await _dbContext.Orders.Include(o => o.Items).FirstAsync(o => o.Id == id);
		}
	}
}