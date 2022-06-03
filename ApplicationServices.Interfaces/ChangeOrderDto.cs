using System.Collections.Generic;

namespace ApplicationServices.Interfaces
{
    public class ChangeOrderDto
    {
        public List<OrderItemDto> Items { get; set; }
    }
}