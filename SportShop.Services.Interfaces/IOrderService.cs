using SportShop.Domain.Core.DTO;

namespace SportShop.Services.Interfaces
{
	public interface IOrderService
	{
		Task<IEnumerable<OrderDto>> GetOrdersAsync(CancellationToken cancellationToken = default);

		Task<OrderDto> GetOrderByIdAsync(int orderDtoId, CancellationToken cancellationToken = default);

		Task UpdateOrderAsync(OrderDto orderDto, CancellationToken cancellationToken = default);

		Task CreateOrderAsync(OrderDto orderDto, CancellationToken cancellationToken = default);

		Task DeleteOrderAsync(OrderDto orderdto, CancellationToken cancellationToken = default);
	}
}
