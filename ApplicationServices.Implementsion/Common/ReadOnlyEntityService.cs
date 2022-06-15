using System.Linq;
using System.Threading.Tasks;
using ApplicationServices.Interfaces.Commnon;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Entities;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApplicationServices.Implementsion.Common
{
	public abstract class ReadOnlyEntityService<TEntity, TDto> : IReadOnlyEntityService<TDto> where TEntity : Entity
	{
		protected readonly IReadOnlyDbContext _readOnlyDbContext;
		protected readonly IMapper _mapper;

		protected ReadOnlyEntityService(IReadOnlyDbContext readOnlyDbContext, IMapper mapper)
		{
			_readOnlyDbContext = readOnlyDbContext;
			_mapper = mapper;
		}

		public virtual async Task<TDto> Get(int id)
		{
			return await _readOnlyDbContext.Set<TEntity>()
				.Where(e => e.Id == id)
				.ProjectTo<TDto>(_mapper.ConfigurationProvider)
				.SingleAsync();
		}
	}
}