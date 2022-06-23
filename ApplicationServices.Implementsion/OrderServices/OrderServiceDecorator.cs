using System;
using System.Threading.Tasks;
using ApplicationServices.Interfaces.Order;
using ApplicationServices.Interfaces.Order.Dtos;
using AutoMapper;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Implementsion.OrderServices
{
    public class OrderServiceDecorator : IOrderService
    {
        private readonly IDbContext _dbContext;
        private readonly IOrderService _orderService;
        private readonly ICurrentUserService _currentUserService;

        public OrderServiceDecorator(IDbContext dbContext, IOrderService orderService, ICurrentUserService currentUserService)
        {
            _dbContext = dbContext;
            _orderService = orderService;
            _currentUserService = currentUserService;
        }
        public  Task<int> Create(ChangeOrderDto entity)
        {
            return _orderService.Create(entity);
        }

        public async Task Update(int id, ChangeOrderDto entity)
        {
            var countOrders = await _dbContext.Orders.CountAsync(o => o.Id == id && o.Email == _currentUserService.Email);
            if (countOrders != 1)
            {
                throw new Exception("Order not found");
            }

            await _orderService.Update(id, entity);
        }

        public  Task Delete(int id)
        {
            return _orderService.Delete(id);
        }
    }
}