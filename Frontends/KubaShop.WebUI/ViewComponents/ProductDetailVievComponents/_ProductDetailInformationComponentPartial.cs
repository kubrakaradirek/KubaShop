using Microsoft.AspNetCore.Mvc;

namespace KubaShop.WebUI.ViewComponents.ProductDetailVievComponents
{
    public class _ProductDetailInformationComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
