using System.Threading.Tasks;

namespace ApplicationServices.Interfaces
{
    public interface IOrderService
    {
        Task<int> CreateOrder(ChangeOrderDto changeOrderDto);
        Task EditOrder(int id, ChangeOrderDto changeOrderDto);
    }
}