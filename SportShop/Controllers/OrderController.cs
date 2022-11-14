using Microsoft.AspNetCore.Mvc;
using SportShop.Domain.Core.DTO;
using SportShop.Infrastructure;
using SportShop.Services.Interfaces;

namespace SportShop.Controllers
{
	public class OrderController : Controller
	{
		private readonly IServiceManager _serviceManager;
		private readonly ILogger<OrderController> _logger;
		private CartFeatures _cartFeatures;

		public OrderController(IServiceManager serviceManager, CartFeatures cartFeatures, ILogger<OrderController> logger)
		{
			_serviceManager = serviceManager;
			_cartFeatures = cartFeatures;
			_logger = logger;
		}

		[HttpGet]
		public ViewResult Checkout()
		{
			var order = new OrderDto();			
			return View(order);
		}

		[HttpPost]
		public async Task<IActionResult> Checkout([FromForm] OrderDto order)
		{
			if (!_cartFeatures.Lines.Any())
			{
				_logger.LogError($"Cart is empty!");
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
