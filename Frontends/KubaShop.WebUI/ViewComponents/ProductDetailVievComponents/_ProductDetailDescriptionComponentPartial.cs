using Microsoft.AspNetCore.Mvc;

namespace KubaShop.WebUI.ViewComponents.ProductDetailVievComponents
{
    public class _ProductDetailDescriptionComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
