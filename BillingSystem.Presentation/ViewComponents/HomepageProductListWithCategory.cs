using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.ViewComponents
{
    public class HomepageProductListWithCategory : ViewComponent
    {
        public IViewComponentResult Invoke()
        {

            return View();
        }
    }
}
