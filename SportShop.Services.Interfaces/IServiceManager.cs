namespace SportShop.Services.Interfaces
{
	public interface IServiceManager
	{
		IOrderService OrderService { get; }

		IStoreService StoreService { get; }
	}
}
