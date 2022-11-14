using Microsoft.AspNetCore.Mvc;
using SportShop.Domain.Core.DTO;
using SportShop.Services.Interfaces;

namespace SportShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IServiceManager serviceManager, ILogger<HomeController> logger)
        {
            _serviceManager = serviceManager;
            _logger = logger;
        }

        public int PageSize = 4;

        [HttpGet]
        public async Task<ViewResult> Index([FromRoute]string category, [FromRoute] int productPage = 1)
        {
            _logger.LogInformation($"{nameof(Index)} method was called.");
            var productsDto = await _serviceManager.StoreService.GetProductsAsync();

            var productsForPaging = productsDto
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductId)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize);

            var pagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
				TotalItems = category == null ? productsDto.Count() : 
                    productsDto.Where(e => e.Category == category).Count(),
            };

            var productsListDto = new ProductsListDto
            {
                Products = productsForPaging,
                PagingInfo = pagingInfo,
                CurrentCategory = category,
            };

            return View(productsListDto);
        }
    }
}
