using System.Threading.Tasks;

namespace ApplicationServices.Interfaces.Commnon
{
	public interface IReadOnlyEntityService<TDto>
	{
		Task<TDto> Get(int id);
	}
}