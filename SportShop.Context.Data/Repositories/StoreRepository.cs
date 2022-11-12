using Microsoft.EntityFrameworkCore;
using SportShop.Domain.Core.Models;
using SportShop.Domain.Interfaces;

namespace SportShop.Context.Data.Repositories
{
	public class StoreRepository : IStoreRepository
	{
		private RepositoryDbContext _context;

		public StoreRepository(RepositoryDbContext ctx)
		{
			_context = ctx;
		}

		public async Task<Product> GetProductByIdAsync(int productId, CancellationToken cancellationToken = default)
		{
			var product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == productId, cancellationToken);

			return product;
		}

		public async Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken = default)
		{
			var products = await _context.Products.ToListAsync(cancellationToken);

			return products;
		}

		public void InsertProduct(Product product)
		{
			_context.Products.Add(product);
		}

		public void DeleteProduct(Product product)
		{
			_context.Remove(product);
		}
	}
}
