using SportShop.Domain.Core.DTO;

namespace SportShop.Infrastructure
{
    public class CartFeatures
    {
        private List<CartLine> lines = new List<CartLine>();

        public IReadOnlyList<CartLine> Lines { get { return lines; } }

        public void AddItem(ProductDto product, int quantity)
        {
            var line = lines
                .Where(p => p.Product.ProductId == product.ProductId)
                .FirstOrDefault();

            if (line is null)
            {
                lines.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity,
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(ProductDto product)
        {
            lines.RemoveAll(l => l.Product.ProductId == product.ProductId);
        }

        public decimal ComputeTotalValue()
        {
            var total = lines.Sum(e => e.Product.Price * e.Quantity);
            return total;
        }

        public void Clear()
        {
            lines.Clear();
        }
    }
}
