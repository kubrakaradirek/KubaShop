using Microsoft.AspNetCore.Mvc;

namespace KubaShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _HeadUILayoutComponentPartial:ViewComponent
    {
        //View componentin amacı sayfaları partiallara ayırmaktır.
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
