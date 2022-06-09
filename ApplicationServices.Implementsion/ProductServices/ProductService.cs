using ApplicationServices.Implementsion.Common;
using ApplicationServices.Interfaces.Product;
using ApplicationServices.Interfaces.Product.Dtos;
using AutoMapper;
using Entities;
using Infrastracture.Interfaces;

namespace ApplicationServices.Implementsion.ProductServices {
	public class ProductService : EntityService<Product, ChangeProductDto>, IProductService
	{
		public ProductService(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
		{
		}
	}
}