using BillingSystem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create(int id)
        {
            ViewData["TableId"] = id;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Order order)
        {
            return View();
        }
    }
}
