using SportShop.Domain.Core.DTO;

namespace SportShop.Infrastructure
{
    public class CartLine
    {
        public int CartLineId { get; set; }

        public ProductDto Product { get; set; } = new();

        public int Quantity { get; set; }
    }
}
