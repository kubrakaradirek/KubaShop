using Microsoft.AspNetCore.Mvc;

namespace KubaShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
