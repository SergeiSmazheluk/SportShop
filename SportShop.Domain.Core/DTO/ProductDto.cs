﻿namespace SportShop.Domain.Core.DTO
{
	public class ProductDto
	{
		public long ProductId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string Description { get; set; } = string.Empty;

		public decimal Price { get; set; }

		public string Category { get; set; } = string.Empty;

		public int Quantity { get; set; }
	}
}
