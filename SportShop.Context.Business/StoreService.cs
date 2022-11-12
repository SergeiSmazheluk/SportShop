using Mapster;
using SportShop.Domain.Core.DTO;
using SportShop.Domain.Core.Models;
using SportShop.Domain.Interfaces;
using SportShop.Services.Interfaces;

namespace SportShop.Context.Business
{
    public class StoreService : IStoreService
    {
        private readonly IRepositoryManager _repositoryManager;

        public StoreService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<ProductDto> GetProductByIdAsync(int productId, CancellationToken cancellationToken = default)
        {
            if (productId < 1)
            {
                throw new ValidationException("Product's Id is not set!", string.Empty);
            }

            var product = await _repositoryManager.StoreRepository.GetProductByIdAsync(productId, cancellationToken);

            if (product is null)
            {
                throw new ValidationException("Product is not found!", string.Empty);
            }

            var productDto = product.Adapt<ProductDto>();

            return productDto;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync(CancellationToken cancellationToken = default)
        {
            var products = await _repositoryManager.StoreRepository.GetProductsAsync(cancellationToken);

            var productsDto = products.Adapt<IEnumerable<ProductDto>>();

            return productsDto;
        }

        public async Task UpdateProductAsync(ProductDto productDto, CancellationToken cancellationToken = default)
        {
            if (productDto is null)
            {
                throw new ValidationException("Product details are not provided", $"{productDto}");
            }

            var product = await _repositoryManager.StoreRepository.GetProductByIdAsync(productDto.ProductId, cancellationToken);

            if (product is null)
            {
                throw new ValidationException("Product with such id does not exist", $"{product.ProductId}");
            }

            product.Name = productDto.Name;
            product.Description = productDto.Description;
            product.Price = productDto.Price;
            product.Category = productDto.Category;
            product.Quantity = productDto.Quantity;

            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }

        public async Task CreateProductAsync(ProductDto productDto, CancellationToken cancellationToken = default)
        {
            if (productDto is null)
            {
                throw new ValidationException("Product can be not provided!", $"{productDto}");
            }

            var product = productDto.Adapt<Product>();

            _repositoryManager.StoreRepository.InsertProduct(product);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteProductAsync(ProductDto productDto, CancellationToken cancellationToken = default)
        {
            if (productDto is null)
            {
                throw new ValidationException("Product can be not provided!", $"{productDto}");
            }

            var product = await _repositoryManager.StoreRepository.GetProductByIdAsync(productDto.ProductId, cancellationToken);

            if (product is null)
            {
                throw new ValidationException("Product with such id does not exist", $"{product.ProductId}");
            }

            _repositoryManager.StoreRepository.DeleteProduct(product);

            await _repositoryManager.UnitOfWork.SaveChangesAsync();
        }     
    }
}
