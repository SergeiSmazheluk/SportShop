using SportShop.Domain.Core.DTO;

namespace SportShop.Infrastructure
{
	public class CartFeatures
	{
		private List<CartLine> _lines = new();

		public IReadOnlyList<CartLine> Lines
		{
			get
			{
				return _lines;
			}
		}

		public virtual void AddItem(ProductDto product, int quantity)
		{
			var line = _lines
				.Where(p => p.Product.ProductId == product.ProductId)
				.FirstOrDefault();

			if (line is null)
			{
				_lines.Add(new CartLine
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

		public virtual void RemoveLine(ProductDto product)
		{
			_lines.RemoveAll(l => l.Product.ProductId == product.ProductId);
		}

		public decimal ComputeTotalValue()
		{
			var total = _lines.Sum(e => e.Product.Price * e.Quantity);
			return total;
		}

		public virtual void Clear()
		{
			_lines.Clear();
		}
	}
}
