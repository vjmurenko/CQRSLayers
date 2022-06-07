using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Implementsion
{
	public class ReadOnlyOrderService : IReadOnlyOrderService
	{
		private readonly IReadOnlyDbContext _dbContext;
		private readonly IMapper _mapper;

		public ReadOnlyOrderService(IReadOnlyDbContext dbContext, IMapper mapper)
		{
			_dbContext = dbContext;
			_mapper = mapper;
		}

		public async Task<OrderDto> GetOrderByIdAsync(int id)
		{
			return await _dbContext.Orders
				.Where(o => o.Id == id)
				.ProjectTo<OrderDto>(_mapper.ConfigurationProvider)
				.SingleAsync();
		}
	}
}