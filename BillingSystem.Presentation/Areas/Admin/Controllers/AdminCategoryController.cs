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
            return View();
        }

        // GET: AdminCategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
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
            return View();
        }

        // POST: AdminCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
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
            return View();
        }

        // POST: AdminCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
