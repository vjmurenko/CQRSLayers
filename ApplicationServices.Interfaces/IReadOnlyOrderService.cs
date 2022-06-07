using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
	public interface IReadOnlyOrderService
	{
		Task<OrderDto> GetOrderByIdAsync(int id);
	}
}