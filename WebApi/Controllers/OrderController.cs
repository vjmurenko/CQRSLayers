using System.Threading.Tasks;
using ApplicationServices.Interfaces.Order;
using ApplicationServices.Interfaces.Order.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebApi.Filters;

namespace WebApi.Controllers {
	[ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IReadOnlyOrderService _readOnlyOrderService;

        public OrderController(IOrderService orderService, IReadOnlyOrderService readOnlyOrderService)
        {
            _orderService = orderService;
            _readOnlyOrderService = readOnlyOrderService;
        }
        
        [CheckOrderFilter]
        [HttpGet("{id}")]
        public async Task<OrderDto> Get(int id)
        {
            return await _readOnlyOrderService.Get(id);
        }

        [HttpPost]
        public async Task<int> Create([FromBody]ChangeOrderDto changeOrderDto)
        {
            return await _orderService.Create(changeOrderDto);
        }
        
        [CheckOrderFilter]
        [HttpPut("{id}")]
        public async Task Edit(int id,[FromBody] ChangeOrderDto changeOrderDto)
        { 
            await _orderService.Update(id, changeOrderDto);
        }
    }
}