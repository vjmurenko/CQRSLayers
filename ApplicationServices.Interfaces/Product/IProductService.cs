using System.Threading.Tasks;
using ApplicationServices.Interfaces.Commnon;
using ApplicationServices.Interfaces.Product.Dtos;

namespace ApplicationServices.Interfaces.Product
{
    public interface IProductService : IEntityService<ChangeProductDto>
    {
        Task DeleteAll(DeleteAllDto deleteAllDto);
    }
}