using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOrderController : Controller
    {
        private readonly IOrderService _orderService;

        public AdminOrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateOrder(int id)
        {
            ViewBag.TableId = id;
            return View();
        }
        [HttpPost]
        public IActionResult CreateOrder(Order order)
        {
            if (order.OrderId is 0)
            {
                _orderService.Add(order);
                return RedirectToAction("Index", "AdminTable");
            }
            Order? value = _orderService.GetAll().Where(x => x.TableId.Equals(order.TableId)).Last();
            if (value is not null)
            {
                return RedirectToAction("Index", "AdminTable");
            }
            else if (value is null)
            {
                _orderService.Add(order);
                return View();
            }
            return View();
        }

    }
}
