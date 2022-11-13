namespace SportShop.Domain.Core.DTO
{
    public class CartLine
    {
        public int CartLineId { get; set; }

        public ProductDto Product { get; set; } = new();

        public int Quantity { get; set; }
    }
}
