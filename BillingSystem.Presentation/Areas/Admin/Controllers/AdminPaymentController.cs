using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.BusinessLayer.Concrete;
using BillingSystem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

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

            ViewBag.OrderId = value.OrderId;
            ViewBag.TableId = id;
            return View();
        }
        [HttpPost]
        public IActionResult PayOrder(Payment payment)
        {
            Order orderValue = _orderService.GetById(payment.OrderId);
            // Sipariş bilgisi, ödeme yapılan siparişin masa ID'sine göre alınır.
            Order value = _orderService.GetOrderForTableId(orderValue.TableId);

            // Masa boş olacak şekilde güncelleme yapılır.
            Table tableValue = _tableService.GetById(value.TableId);
            tableValue.IsOccupied = false;
            _tableService.Update(tableValue);


            // Sipariş bilgisi ödendi olarak güncellenir.
            value.IsPaid = true;
            _orderService.Update(value);

            // Ödeme bilgisi eklenir.
            _paymentService.Add(payment);
            // İşlem tamamlandıktan sonra AdminTable sayfasına yönlendirilir.
            return RedirectToAction("index", "AdminTable");
        }
    }
}
