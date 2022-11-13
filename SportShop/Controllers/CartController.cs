using Microsoft.AspNetCore.Mvc;
using SportShop.Infrastructure;
using SportShop.Services.Interfaces;

namespace SportShop.Controllers
{
    public class CartController : Controller
    {
        private readonly IServiceManager _servicesManager;

        public CartController(IServiceManager servicesManager, CartFeatures cart)
        {
            _servicesManager = servicesManager;
            CartFeature = cart;
        }

        public CartFeatures CartFeature { get; set; }

        [HttpGet]
        public IActionResult Index(string returnUrl)
        {
            var cartViewInfo = new CartViewInfo
            {
                ReturnUrl = returnUrl ?? "/",
                Cart = CartFeature,
            };

            return View(cartViewInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int productId, string returnUrl)
        {
            var product = await _servicesManager.StoreService.GetProductByIdAsync(productId);

            if (product != null)
            {
                CartFeature.AddItem(product, 1);
                var cartViewInfo = new CartViewInfo { Cart = CartFeature, ReturnUrl = returnUrl };

                return View(cartViewInfo);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
