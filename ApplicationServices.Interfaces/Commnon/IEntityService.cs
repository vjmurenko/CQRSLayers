using System.Threading.Tasks;

namespace ApplicationServices.Interfaces.Commnon
{
	public interface IEntityService<TDto>
	{
		Task<int> Create(TDto entity);
		Task Update(int id, TDto entity);
		Task Delete(int id);
	}
}