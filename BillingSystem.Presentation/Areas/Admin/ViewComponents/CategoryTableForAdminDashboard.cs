using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Areas.Admin.ViewComponents
{
    public class CategoryTableForAdminDashboard : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryTableForAdminDashboard(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<Category> Values = _categoryService.GetAll().Take(5);
            return View(Values);
        }
    }
}
