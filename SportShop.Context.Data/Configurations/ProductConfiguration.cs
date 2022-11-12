using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportShop.Domain.Core.Models;

namespace SportShop.Context.Data.Configurations
{
	internal sealed class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable(nameof(Product));

			builder.HasKey(product => product.ProductId);

			builder.Property(product => product.ProductId).ValueGeneratedOnAdd();

			builder.Property(product => product.Name).ValueGeneratedOnAdd();

			builder.Property(product => product.Category).IsRequired();

			builder.Property(product => product.Description).IsRequired();

			builder.Property(product => product.Price).IsRequired().HasPrecision(8, 2); ;

			builder.Property(product => product.Quantity).IsRequired();
		}
	}
}
