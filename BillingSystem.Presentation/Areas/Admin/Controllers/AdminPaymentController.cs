using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.BusinessLayer.Concrete;
using BillingSystem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminPaymentController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IPaymentService _paymentService;

        public AdminPaymentController(IOrderService orderService, IPaymentService paymentService)
        {
            _orderService = orderService;
            _paymentService = paymentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PayOrder(int id)
        {
            Order value = _orderService.GetOrderForTableId(id);
            ViewBag.OrderId = value.OrderId;
            return View();
        }
        [HttpPost]
        public IActionResult PayOrder(Payment payment)
        {
            _paymentService.Add(payment);
            //_orderService.Delete(_orderService.GetById(payment.OrderId));
            return RedirectToAction("index", "AdminTable");
        }
    }
}
