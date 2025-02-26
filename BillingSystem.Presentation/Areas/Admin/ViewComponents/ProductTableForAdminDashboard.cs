using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Areas.Admin.ViewComponents
{
    public class ProductTableForAdminDashboard:ViewComponent
    {
        private readonly IProductService _productService;

        public ProductTableForAdminDashboard(IProductService productService)
        {
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<Product> Values = _productService.GetAll().Take(5);
            return View(Values);
        }
    }
}
