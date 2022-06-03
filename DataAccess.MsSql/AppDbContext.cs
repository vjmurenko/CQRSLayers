using Entities;
using Infrastracture.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.MsSql
{
	public class AppDbContext : DbContext, IDbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }

		public new DbSet<TEntity> Set<TEntity>() where TEntity : Entity
		{
			return base.Set<TEntity>();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<OrderItem>().HasKey(o => new {o.OrderId, o.ProductId});

			modelBuilder.Entity<Product>().HasData(
				new Product {Id = 1, Name = "Pepsi", Price = 100},
				new Product {Id = 2, Name = "Milk", Price = 200});
		}
	}
}