using Microsoft.AspNetCore.Mvc;
using SportShop.Infrastructure;

namespace SportShop.Components
{
	public class CartSummaryViewComponent : ViewComponent
	{
		private CartFeatures _cart;

		public CartSummaryViewComponent(CartFeatures cart)
		{
			_cart = cart;
		}

		public IViewComponentResult Invoke()
		{
			return View(_cart);
		}
	}
}
