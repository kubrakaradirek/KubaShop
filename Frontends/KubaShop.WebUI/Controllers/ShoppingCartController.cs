using Microsoft.AspNetCore.Mvc;

namespace KubaShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
