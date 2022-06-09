using ApplicationServices.Implementsion.Common;
using ApplicationServices.Interfaces.Product;
using ApplicationServices.Interfaces.Product.Dtos;
using AutoMapper;
using Entities;
using Infrastracture.Interfaces;

namespace ApplicationServices.Implementsion.ProductServices
{
	public class ReadOnlyProductService : ReadOnlyEntityService<Product, ProductDto>, IReadOnlyProductService
	{
		public ReadOnlyProductService(IReadOnlyDbContext readOnlyDbContext, IMapper mapper) : base(readOnlyDbContext, mapper)
		{
		}
	}
}