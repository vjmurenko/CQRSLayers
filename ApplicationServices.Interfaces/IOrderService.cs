using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IOrderService
    {
        Task<OrderDto> GetOrderByIdAsync(int id);
        Task<int> CreateOrder(ChangeOrderDto changeOrderDto);
        Task EditOrder(int id, ChangeOrderDto changeOrderDto);
    }
}