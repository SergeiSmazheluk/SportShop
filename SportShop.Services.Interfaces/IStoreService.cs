using SportShop.Domain.Core.DTO;

namespace SportShop.Services.Interfaces
{
	public interface IStoreService
	{
		Task<IEnumerable<ProductDto>> GetProductsAsync(CancellationToken cancellationToken = default);

		Task<ProductDto> GetProductByIdAsync(int productId, CancellationToken cancellationToken = default);

		Task UpdateProductAsync(ProductDto productDto, CancellationToken cancellationToken = default);

		Task CreateProductAsync(ProductDto productDto, CancellationToken cancellationToken = default);

		Task DeleteProductAsync(ProductDto productDto, CancellationToken cancellationToken = default);
	}
}
