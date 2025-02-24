using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCategoryController : Controller
    {
        private readonly ICategoryService _categoryServices;

        public AdminCategoryController(ICategoryService categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // GET: AdminCategoryController
        public ActionResult Index()
        {
            List<Category> Values = _categoryServices.GetAll();
            return View(Values);
        }

        // GET: AdminCategoryController/Details/5
        public ActionResult Details(int id)
        {
            Category Value = _categoryServices.GetById(id);
            return View(Value);
        }

        // GET: AdminCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category c)
        {
            try
            {
                c.CreatedDate = DateTime.Now;
                _categoryServices.Add(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminCategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            Category Value = _categoryServices.GetById(id);
            return View(Value);
        }

        // POST: AdminCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Category c)
        {
            try
            {
                c.ModifiedDate = DateTime.Now;
                _categoryServices.Update(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminCategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            Category Value = _categoryServices.GetById(id);
            return View(Value);
        }

        // POST: AdminCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Category c)
        {
            try
            {
                _categoryServices.Delete(c);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
