using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminTableController : Controller
    {
        private readonly ITableService _tableService;

        public AdminTableController(ITableService tableService)
        {
            _tableService = tableService;
        }

        // GET: AdminTableController
        public ActionResult Index()
        {
            List<Table> values = _tableService.GetAll();
            return View(values);
        }

        // GET: AdminTableController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminTableController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminTableController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Table table)
        {
            try
            {
                table.IsOccupied = false;
                _tableService.Add(table);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminTableController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminTableController/Edit/5
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

        // GET: AdminTableController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminTableController/Delete/5
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
