using Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Interfaces
{
	public interface IReadOnlyDbContext
	{
		DbSet<Order> Orders { get; }
		DbSet<Product> Products { get; }
	}
}