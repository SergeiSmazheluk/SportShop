using SportShop.Domain.Core.Models;


namespace SportShop.Domain.Interfaces
{
	public interface IStoreRepository
	{
		Task<IEnumerable<Product>> GetProductsAsync(CancellationToken cancellationToken = default);

		Task<Product> GetProductByIdAsync(int productId, CancellationToken cancellationToken = default);

		void InsertProduct(Product product);

		void DeleteProduct(Product product);
	}
}
