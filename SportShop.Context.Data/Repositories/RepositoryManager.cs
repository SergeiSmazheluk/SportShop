using SportShop.Domain.Interfaces;

namespace SportShop.Context.Data.Repositories
{
	public sealed class RepositoryManager : IRepositoryManager
	{
		private readonly Lazy<IOrderRepository> _lazyOrderRepository;
		private readonly Lazy<IStoreRepository> _lazyStoreRepository;
		private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

		public RepositoryManager(RepositoryDbContext dbContext)
		{
			_lazyOrderRepository = new Lazy<IOrderRepository>(() => new OrderRepository(dbContext));
			_lazyStoreRepository = new Lazy<IStoreRepository>(() => new StoreRepository(dbContext));
			_lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
		}


		public IOrderRepository OrderRepository
		{
			get
			{
				var orderRepository = _lazyOrderRepository.Value;

				return orderRepository;
			}
		}

		public IStoreRepository StoreRepository
		{
			get
			{
				var storeRepository = _lazyStoreRepository.Value;

				return storeRepository;
			}
		}

		public IUnitOfWork UnitOfWork
		{
			get
			{
				var unitOfWork = _lazyUnitOfWork.Value;

				return unitOfWork;
			}
		}
	}
}
