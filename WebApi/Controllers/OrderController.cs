using System.Threading.Tasks;
using ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("{id}")]
        public async Task<OrderDto> Get(int id)
        {
            return await _orderService.GetOrderByIdAsync(id);
        }

        [HttpPost]
        public async Task<int> Create([FromBody]ChangeOrderDto changeOrderDto)
        {
            return await _orderService.CreateOrder(changeOrderDto);
        }

        [HttpPut("{id}")]
        public async Task Edit(int id,[FromBody] ChangeOrderDto changeOrderDto)
        { 
            await _orderService.EditOrder(id, changeOrderDto);
        }
    }
}