using Microsoft.AspNetCore.Mvc;
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

		public async Task<IActionResult> Index()
		{
			var products = await _serviceManager.StoreService.GetProductsAsync();

			return View(products);
		}
	}
}
