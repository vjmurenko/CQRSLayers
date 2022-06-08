﻿using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.Interfaces;
using AutoMapper;
using Entities;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Implementsion
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IDbContext _dbContext;
        private readonly ICurrentUserService _currentUserService;
        private readonly IStatisticService _statisticService;

        public OrderService(IMapper mapper, IDbContext dbContext, ICurrentUserService currentUserService, IStatisticService statisticService)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _currentUserService = currentUserService;
            _statisticService = statisticService;
        }

        public async Task<int> CreateOrder(ChangeOrderDto changeOrderDto)
        {
            var order = _mapper.Map<Order>(changeOrderDto);
            order.Email = _currentUserService.Email;
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order.Id;
        }

        public async Task EditOrder(int id, ChangeOrderDto changeOrderDto)
        {
            await _statisticService.WriteStatisticAsync("Order", changeOrderDto.Items.Select(s => s.ProductId));
            
            var order = await _dbContext.Orders
                .Include(o => o.Items)
                .FirstAsync(o => o.Id == id);
            
            _mapper.Map(changeOrderDto, order);
            
            await _dbContext.SaveChangesAsync();
        }
    }
}