using Microsoft.AspNetCore.Mvc;
using SportShop.Infrastructure;
using SportShop.Services.Interfaces;

namespace SportShop.Controllers
{
    public class CartController : Controller
    {
        private readonly IServiceManager _servicesManager;

        public CartController(IServiceManager servicesManager)
        {
            _servicesManager = servicesManager;
        }

        [HttpGet]
        public IActionResult Index(string returnUrl)
        {
            var cartViewInfo = new CartViewInfo
            {
                ReturnUrl = returnUrl ?? "/",
                Cart = HttpContext.Session.GetJson<CartFeatures>("cart") ?? new CartFeatures(),
            };

            return View(cartViewInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Index(int productId, string returnUrl)
        {
            var product = await _servicesManager.StoreService.GetProductByIdAsync(productId);

            if (product != null)
            {
                var cart = HttpContext.Session.GetJson<CartFeatures>("cart") ?? new CartFeatures();
                cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart", cart);
                var cartViewInfo = new CartViewInfo { Cart = cart, ReturnUrl = returnUrl };

                return View(cartViewInfo);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
