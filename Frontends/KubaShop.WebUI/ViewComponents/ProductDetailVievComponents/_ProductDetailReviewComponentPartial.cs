using Microsoft.AspNetCore.Mvc;

namespace KubaShop.WebUI.ViewComponents.ProductDetailVievComponents
{
    public class _ProductDetailReviewComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
