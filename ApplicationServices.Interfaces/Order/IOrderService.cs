using ApplicationServices.Interfaces.Commnon;
using ApplicationServices.Interfaces.Order.Dtos;

namespace ApplicationServices.Interfaces.Order
{
	public interface IOrderService : IEntityService<ChangeOrderDto>
	{
	}
}