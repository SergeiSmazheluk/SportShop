namespace SportShop.Domain.Core.DTO
{
    public class ProductsListDto
    {
        public IEnumerable<ProductDto> Products { get; set; } = Enumerable.Empty<ProductDto>();

        public PagingInfo PagingInfo { get; set; } = new();

        public string CurrentCategory { get; set; }
    }
}
