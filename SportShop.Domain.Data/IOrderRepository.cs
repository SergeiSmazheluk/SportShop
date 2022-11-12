using SportShop.Domain.Core.Models;

namespace SportShop.Domain.Interfaces
{
	public interface IOrderRepository
	{
		Task<IEnumerable<Order>> GetOrdersAsync(CancellationToken cancellationToken = default);

		Task<Order> GetOrderByIdAsync(int orderId, CancellationToken cancellationToken = default);

		void InsertOrder(Order order);

		void DeleteOrder(Order order);
	}
}
