using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BillingSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminOrderItemController : Controller
    {
        private readonly IOrderItemService _orderItemService;
        private readonly IOrderService _orderService;
        private readonly IProductService _productService;

        public AdminOrderItemController(IOrderItemService orderItemService, IOrderService orderService, IProductService productService)
        {
            _orderItemService = orderItemService;
            _orderService = orderService;
            _productService = productService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateOrderItem(int id)
        {
            var order = _orderService.GetOrderForTableId(id);
            if (order is null)
            {
                TempData["Message"] = "Masanın aktif siparişi bulunmamaktadır.";
                return RedirectToAction("index", "AdminTable");
            }
            ViewBag.OrderId = _orderService.GetById(order.OrderId).OrderId;
            List<Product> Values = _productService.GetAll().ToList();
            ViewData["Products"] = Values.Select(c => new SelectListItem
            {
                Value = c.ProductId.ToString(),
                Text = c.ProductName
            }).ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CreateOrderItem(OrderItem orderItem)
        {
            _orderItemService.Add(orderItem);
            return RedirectToAction("Index", "AdminTable");
        }
    }
}
