using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BillingSystem.Presentation.Models;
using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.EntityLayer.Concrete;

namespace BillingSystem.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;

    public HomeController(ILogger<HomeController> logger, IProductService productService, ICategoryService categoryService)
    {
        _logger = logger;
        _productService = productService;
        _categoryService = categoryService;
    }

    public IActionResult Index()
    {
        List<Product> values = _productService.GetAllProductsWithCategory().Where(x => x.IsActive).ToList();
        return View(values);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
