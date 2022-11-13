using Microsoft.AspNetCore.Mvc;
using SportShop.Domain.Core.DTO;

namespace SportShop.Controllers
{
	public class OrderController : Controller
	{
		public ViewResult Checkout()
		{
			var order = new OrderDto();
			
			return View(order);
		}
	}
}
