using Microsoft.AspNetCore.Mvc;
using SportShop.Services.Interfaces;

namespace SportShop.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public NavigationMenuViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            var productsDto = await _serviceManager.StoreService.GetProductsAsync();

            var categories = productsDto
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
