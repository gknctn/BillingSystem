using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BillingSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public AdminProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        // GET: AdminProductController
        public ActionResult Index()
        {
            List<Product> Values = _productService.GetAll();
            return View(Values);
        }

        // GET: AdminProductController/Details/5
        public ActionResult Details(int id)
        {
            Product Value = _productService.GetById(id);
            return View(Value);
        }

        // GET: AdminProductController/Create
        public ActionResult Create()
        {
            var categories = _categoryService.GetAll().ToList();
            ViewData["Categories"] = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();
            return View();
        }

        // POST: AdminProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p)
        {
            try
            {
                _productService.Add(p);
                return RedirectToAction("Index", "AdminProduct");
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var categories = _categoryService.GetAll().ToList();
            ViewData["Categories"] = categories.Select(c => new SelectListItem
            {
                Value = c.CategoryId.ToString(),
                Text = c.CategoryName
            }).ToList();

            Product Value = _productService.GetById(id);
            return View(Value);
        }

        // POST: AdminProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product p)
        {
            try
            {
                p.ModifiedDate = DateTime.Now;
                _productService.Update(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminProductController/Delete/5
        public ActionResult Delete(int id)
        {
            Product Value = _productService.GetById(id);
            return View(Value);
        }

        // POST: AdminProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product p)
        {
            try
            {
                _productService.Delete(p);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
