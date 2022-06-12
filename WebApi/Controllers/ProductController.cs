using System.Threading.Tasks;
using ApplicationServices.Interfaces.Product;
using ApplicationServices.Interfaces.Product.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class ProductController : ControllerBase
	{
		private readonly IReadOnlyProductService _readOnlyProductService;
		private readonly IProductService _productService;

		public ProductController(IReadOnlyProductService readOnlyProductService, IProductService productService)
		{
			_readOnlyProductService = readOnlyProductService;
			_productService = productService;
		}

		[HttpGet("{id}")]
		public async Task<ProductDto> Get(int id)
		{
			return await _readOnlyProductService.Get(id);
		}

		[HttpPost]
		public async Task<int> Create([FromBody] ChangeProductDto changeProductDto)
		{
			return await _productService.Create(changeProductDto);
		}
		
		[HttpPut("{id}")]
		public async Task Update(int id, [FromBody] ChangeProductDto changeProductDto)
		{
			await _productService.Update(id, changeProductDto);
		}

		[HttpDelete("{id}")]
		public async Task Delete(int id)
		{
			await _productService.Delete(id);
		}
	}
}