using Microsoft.EntityFrameworkCore;
using SportShop.Context.Data.Configurations;
using SportShop.Domain.Core.Models;

namespace SportShop.Context.Data
{
	public class RepositoryDbContext : DbContext
	{
		public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
			: base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductConfiguration());
			modelBuilder.ApplyConfiguration(new OrderConfiguration());			
		}
	}
}
