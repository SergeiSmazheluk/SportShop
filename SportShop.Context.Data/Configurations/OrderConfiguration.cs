using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SportShop.Domain.Core.Models;

namespace SportShop.Context.Data.Configurations
{
	internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
	{
		public void Configure(EntityTypeBuilder<Order> builder)
		{
			builder.ToTable(nameof(Order));

			builder.HasKey(order => order.OrderId);

			builder.Property(order => order.OrderId).ValueGeneratedOnAdd();

			builder.Property(order => order.Name).IsRequired();

			builder.Property(order => order.City).IsRequired();

			builder.Property(order => order.Line1).IsRequired();

			builder.Property(order => order.City).IsRequired();

			builder.Property(order => order.State).IsRequired();

			builder.Property(order => order.Country).IsRequired();
		}
	}
}
