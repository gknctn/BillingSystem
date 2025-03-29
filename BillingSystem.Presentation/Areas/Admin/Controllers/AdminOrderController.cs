using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IOrderItemService _orderItemService;
        private readonly ITableService _tableService;
        public AdminOrderController(IOrderService orderService, IOrderItemService orderItemService, ITableService tableService)
        {
            _orderService = orderService;
            _orderItemService = orderItemService;
            _tableService = tableService;
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
                Table TableValue = _tableService.GetById(order.TableId);
                TableValue.IsOccupied = true;
                _tableService.Update(TableValue);
                _orderService.Add(order);
                return RedirectToAction("Index", "AdminTable");
            }

            Order? value = _orderService.GetAll().Where(z => z.IsPaid.Equals(false)).Where(x => x.TableId.Equals(order.TableId)).Last();

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
        public IActionResult ListOrder(int id)
        {
            Order value = _orderService.GetOrderForTableId(id);

            if (value == null)
            {
                TempData["Message"] = "Masanın aktif siparişi bulunmamaktadır.";
                return RedirectToAction("Index", "AdminTable");
            }

            try
            {
                List<OrderItem> Values = _orderItemService.GetOrderItemForOrderId(value.OrderId);
                return View(Values);
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "AdminTable");
            }
        }

    }
}
