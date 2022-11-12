using SportShop.Domain.Core.DTO;
using SportShop.Domain.Interfaces;
using SportShop.Services.Interfaces;
using SportShop.Domain.Core.Models;
using Mapster;

namespace SportShop.Context.Business
{
	public class OrderService : IOrderService
	{
		private readonly IRepositoryManager _repositoryManager;

		public OrderService(IRepositoryManager repositoryManager)
		{
			_repositoryManager = repositoryManager;
		}

		public async Task<OrderDto> GetOrderByIdAsync(int orderId, CancellationToken cancellationToken = default)
		{
			if (orderId < 1)
			{
				throw new ValidationException("Order's Id is not set!", string.Empty);
			}

			var order = await _repositoryManager.OrderRepository.GetOrderByIdAsync(orderId, cancellationToken);

			if (order is null)
			{
				throw new ValidationException("Order is not found!", string.Empty);
			}

			var orderDto = order.Adapt<OrderDto>();

			return orderDto;
		}

		public async Task<IEnumerable<OrderDto>> GetOrdersAsync(CancellationToken cancellationToken = default)
		{
			var orders = await _repositoryManager.OrderRepository.GetOrdersAsync(cancellationToken);

			var ordersDto = orders.Adapt<IEnumerable<OrderDto>>();

			return ordersDto;
		}

		public async Task UpdateOrderAsync(OrderDto orderDto, CancellationToken cancellationToken = default)
		{
			if (orderDto is null)
			{
				throw new ValidationException("Order details are not provided", $"{orderDto}");
			}

			var order = await _repositoryManager.OrderRepository.GetOrderByIdAsync(orderDto.OrderId, cancellationToken);

			if (order is null)
			{
				throw new ValidationException("Order with such id does not exist", $"{order.OrderId}");
			}

			order.Name = orderDto.Name;
			order.Line1 = orderDto.Line1;
			order.Line2 = orderDto.Line2;
			order.Line3 = orderDto.Line3;
			order.City = orderDto.City;
			order.Country = orderDto.Country;
			order.Zip = orderDto.Zip;
			order.GiftWrap = orderDto.GiftWrap;
			order.Shipped = orderDto.Shipped;

			await _repositoryManager.UnitOfWork.SaveChangesAsync();
		}

		public async Task CreateOrderAsync(OrderDto orderDto, CancellationToken cancellationToken = default)
		{
			if (orderDto is null)
			{
				throw new ValidationException("Order can be not provided!", $"{orderDto}");
			}

			var order = orderDto.Adapt<Order>();

			_repositoryManager.OrderRepository.InsertOrder(order);

			await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
		}

		public async Task DeleteOrderAsync(OrderDto orderDto, CancellationToken cancellationToken = default)
		{
			if (orderDto is null)
			{
				throw new ValidationException("Order can be not provided!", $"{orderDto}");
			}

			var order = await _repositoryManager.OrderRepository.GetOrderByIdAsync(orderDto.OrderId, cancellationToken);

			if (order is null)
			{
				throw new ValidationException("Order with such id does not exist", $"{order.OrderId}");
			}

			_repositoryManager.OrderRepository.DeleteOrder(order);

			await _repositoryManager.UnitOfWork.SaveChangesAsync();
		}		
	}
}
