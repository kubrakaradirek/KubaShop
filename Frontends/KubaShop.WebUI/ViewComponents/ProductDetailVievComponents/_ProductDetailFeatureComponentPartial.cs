using Microsoft.AspNetCore.Mvc;

namespace KubaShop.WebUI.ViewComponents.ProductDetailVievComponents
{
    public class _ProductDetailFeatureComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
