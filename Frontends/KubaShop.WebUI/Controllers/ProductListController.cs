using Microsoft.AspNetCore.Mvc;

namespace KubaShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        public IActionResult Index(string id)
        {
            ViewBag.i = id;//Kategoriye gittiğinde kategorideki eşyalara götür
            return View();
        }
        public IActionResult ProductDetail()
        {
            return View();
        }
    }
}
