using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BillingSystem.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminProductController : Controller
    {
        private readonly IProductService _productService;

        public AdminProductController(IProductService productService)
        {
            _productService = productService;
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
            return View();
        }

        // POST: AdminProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                _productService.Add(new Product
                {
                    ProductName = collection["ProductName"],
                    ProductDescription = collection["ProductDescription"],
                    ProductPrice = Convert.ToDecimal(collection["ProductPrice"])
                });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminProductController/Edit/5
        public ActionResult Edit(int id)
        {
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
