using ApplicationServices.Interfaces.Commnon;
using AutoMapper;
using Entities;
using Infrastracture.Interfaces;
using System.Threading.Tasks;


namespace ApplicationServices.Implementsion.Common
{
    public abstract class EntityService<TEntity, TDto> : IEntityService<TDto> where TEntity : Entity, new()
    {
        private readonly IDbContext _dbContext;
        private readonly IMapper _mapper;

        protected EntityService(IDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public virtual async Task<int> Create(TDto entity)
        {
            var mappedEntity = _mapper.Map<TEntity>(entity);
            IniializeNewEntity(mappedEntity);
            _dbContext.Set<TEntity>().Add(mappedEntity);
            await _dbContext.SaveChangesAsync();

            return mappedEntity.Id;
        }

        public virtual async Task Update(int id, TDto tDto)
        {
            var dataFromDb = await GetTrackedEntityAsync(id);
            _mapper.Map(tDto, dataFromDb);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task Delete(int id)
        {
            _dbContext.Set<TEntity>().Remove(new TEntity {Id = id});
            await _dbContext.SaveChangesAsync();
        }

        protected virtual void IniializeNewEntity(TEntity entity)
        {
        }

        protected virtual async Task<TEntity> GetTrackedEntityAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }
    }
}