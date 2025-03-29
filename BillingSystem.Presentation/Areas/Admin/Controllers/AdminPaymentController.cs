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
        private readonly ITableService _tableService;

        public AdminPaymentController(IOrderService orderService, IPaymentService paymentService, ITableService tableService)
        {
            _orderService = orderService;
            _paymentService = paymentService;
            _tableService = tableService;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult PayOrder(int id)
        {
            Order value = _orderService.GetOrderForTableId(id);
            if (value == null)
            {
                TempData["Message"] = "Masanın aktif siparişi bulunmamaktadır.";
                return RedirectToAction("index", "AdminTable");
            }

            // Masa dolu olacak şekilde güncelleme yapılır.
            Table tableValue = _tableService.GetById(id);
            tableValue.IsOccupied = false;
            _tableService.Update(tableValue);

            // Ödeme bilgisi ödendi olarak güncellenir.
            value.IsPaid = true;
            _orderService.Update(value);

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
