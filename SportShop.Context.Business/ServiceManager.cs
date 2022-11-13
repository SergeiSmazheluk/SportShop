using SportShop.Domain.Interfaces;
using SportShop.Services.Interfaces;

namespace SportShop.Context.Business
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IStoreService> _lazyStoreService;
        private readonly Lazy<IOrderService> _lazyOrderService;
        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyStoreService = new Lazy<IStoreService>(() => new StoreService(repositoryManager));
            _lazyOrderService = new Lazy<IOrderService>(() => new OrderService(repositoryManager));
        }

        public IOrderService OrderService => _lazyOrderService.Value;

        public IStoreService StoreService => _lazyStoreService.Value;
    }
}
