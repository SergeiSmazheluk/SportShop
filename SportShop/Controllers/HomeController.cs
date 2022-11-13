using Microsoft.AspNetCore.Mvc;
using SportShop.Domain.Core.DTO;
using SportShop.Services.Interfaces;

namespace SportShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public HomeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public int PageSize = 4;

        public async Task<ViewResult> Index(string category, int productPage = 1)
        {
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
