using Microsoft.AspNetCore.Mvc;

namespace KubaShop.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
