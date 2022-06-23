using System;
using System.Threading.Tasks;
using ApplicationServices.Interfaces.Order;
using ApplicationServices.Interfaces.Order.Dtos;
using AutoMapper;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationServices.Implementsion.OrderServices
{
    public class ReadOnlyOrderServiceDecorator : IReadOnlyOrderService
    {
        private readonly IDbContext _dbContext;
        private readonly IReadOnlyOrderService _orderService;
        private readonly ICurrentUserService _currentUserService;


        public ReadOnlyOrderServiceDecorator(IDbContext dbContext, IReadOnlyOrderService orderService, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _orderService = orderService;
            _currentUserService = currentUserService;
        }

        public async Task<OrderDto> Get(int id)
        {
            var countOrders = await _dbContext.Orders.CountAsync(o => o.Id == id && o.Email == _currentUserService.Email);
            if (countOrders != 1)
            {
                throw new Exception("Order not found");
            }

            return await _orderService.Get(id);
        }
    }
}