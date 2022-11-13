using Microsoft.AspNetCore.Mvc;
using SportShop.Infrastructure;

namespace SportShop.Components
{
	public class CartSummaryViewComponent : ViewComponent
	{
		private CartFeatures cart;

		public CartSummaryViewComponent(CartFeatures cart)
		{
			this.cart = cart;
		}

		public IViewComponentResult Invoke()
		{
			return View(cart);
		}
	}
}
