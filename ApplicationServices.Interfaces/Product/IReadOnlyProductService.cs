using ApplicationServices.Interfaces.Commnon;
using ApplicationServices.Interfaces.Product.Dtos;

namespace ApplicationServices.Interfaces.Product
{
	public interface IReadOnlyProductService : IReadOnlyEntityService<ProductDto>
	{
	}
}