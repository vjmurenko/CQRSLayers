using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationServices.Interfaces.Order {
	public interface IStatisticService {
		Task WriteStatisticAsync(string area,int id);
		Task WriteStatisticAsync(string area,IEnumerable<int> productIds);
	}
}