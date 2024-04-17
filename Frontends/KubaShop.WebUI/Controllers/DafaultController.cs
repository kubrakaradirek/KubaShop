using Microsoft.AspNetCore.Mvc;

namespace KubaShop.WebUI.Controllers
{
    public class DafaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
