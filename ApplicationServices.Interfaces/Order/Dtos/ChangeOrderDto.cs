using System.Collections.Generic;

namespace ApplicationServices.Interfaces.Order.Dtos {
	public class ChangeOrderDto {
		public List<OrderItemDto> Items { get; set; }
	}
}