namespace SportShop.Domain.Interfaces
{
	public interface IRepositoryManager
	{
		IOrderRepository OrderRepository { get; }

		IStoreRepository StoreRepository { get; }

		IUnitOfWork UnitOfWork { get; }
	}
}
