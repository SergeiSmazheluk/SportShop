using Microsoft.EntityFrameworkCore;
using SportShop.Domain.Core.Models;
using SportShop.Domain.Interfaces;

namespace SportShop.Context.Data.Repositories
{
	public class OrderRepository : IOrderRepository
	{
		private RepositoryDbContext _context;

		public OrderRepository(RepositoryDbContext context)
		{
			_context = context;
		}

		public async Task<Order> GetOrderByIdAsync(int orderId, CancellationToken cancellationToken = default)
		{
			var order = await _context.Orders.FirstOrDefaultAsync(o => o.OrderId == orderId, cancellationToken);

			return order;
		}

		public async Task<IEnumerable<Order>> GetOrdersAsync(CancellationToken cancellationToken = default)
		{
			var orders = await _context.Orders.ToListAsync(cancellationToken);

			return orders;
		}


		public void InsertOrder(Order order)
		{
			_context.Add(order);
		}

		public void DeleteOrder(Order order)
		{
			_context.Remove(order);
		}
	}
}
