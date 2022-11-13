using Microsoft.AspNetCore.Mvc;

namespace SportShop.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
