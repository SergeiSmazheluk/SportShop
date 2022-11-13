using Microsoft.AspNetCore.Mvc;
using SportShop.Domain.Core.DTO;
using SportShop.Infrastructure;
using SportShop.Services.Interfaces;

namespace SportShop.Controllers
{
	public class OrderController : Controller
	{
		private readonly IServiceManager _serviceManager;

		private CartFeatures _cartFeatures;

		public OrderController(IServiceManager serviceManager, CartFeatures cartFeatures)
		{
			_serviceManager = serviceManager;
			_cartFeatures = cartFeatures;
		}

		[HttpGet]
		public ViewResult Checkout()
		{
			var order = new OrderDto();
			
			return View(order);
		}

		[HttpPost]
		public async Task<IActionResult> Checkout(OrderDto order)
		{
			if (!_cartFeatures.Lines.Any())
			{
				ModelState.AddModelError(string.Empty, "Sorry, your cart is empty!");
			}

			if (ModelState.IsValid)
			{
				await _serviceManager.OrderService.CreateOrderAsync(order);

				return View("Completed", order.OrderId);
			}

			return View();
		}
	}
}
