using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ApplicationServices.Interfaces.Order.Dtos;
using Entities;
using Infrastracture.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using WebApi;
using Xunit;

namespace Tests
{
    public class OrdersTests
    {
        [Fact]
        public async Task CheckOrders()
        {

            var builder = new WebHostBuilder().UseEnvironment("Testing").UseStartup<Startup>();
            var server = new TestServer(builder);
            var client = server.CreateClient();
            var dbContext = server.Host.Services.GetRequiredService<IDbContext>();
            var currentUserService = server.Host.Services.GetRequiredService<ICurrentUserService>();
            
            dbContext.Orders.AddRange(new[]
            {
                new Order() {Id = 1, Email = "abc@mail.ru", Items = new List<OrderItem>(){new (){OrderId = 1, ProductId = 1}}},
                new Order() {Id = 2, Email = currentUserService.Email, Items = new List<OrderItem>(){new(){OrderId = 2, ProductId = 2}}}
            });
            
            await dbContext.SaveChangesAsync();
            
            var orders = await dbContext.Orders.ToListAsync();
            
            var changeDto = new ChangeOrderDto(){Items = new List<OrderItemDto>(){new OrderItemDto(){ProductId = 1, Quantity = 1}}};
            var changeString = JsonConvert.SerializeObject(changeDto);
            var httpContent = new StringContent(changeString, Encoding.UTF8, "application/json");
            
            var getResponse1 = await client.GetAsync($"Order/{1}");
            var getResponse2 = await client.GetAsync($"Order/{2}");
            
            var putResponse1 = await client.PutAsync($"Order/{1}", httpContent);
            var putResponse2 = await client.PutAsync($"Order/{2}", httpContent);
            
            var postResponse = await client.PostAsync("Order", httpContent);
            
            Assert.False(getResponse1.IsSuccessStatusCode);
            Assert.True(getResponse2.IsSuccessStatusCode);
            
            Assert.False(putResponse1.IsSuccessStatusCode);
            Assert.True(putResponse2.IsSuccessStatusCode);
            
            Assert.True(postResponse.IsSuccessStatusCode);
        }
    }
}