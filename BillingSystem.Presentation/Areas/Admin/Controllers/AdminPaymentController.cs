using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPaymentController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }
    }
}
