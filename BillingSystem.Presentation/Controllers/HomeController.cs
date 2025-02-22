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
    public HomeController(ILogger<HomeController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public IActionResult Index()
    {
        List<Product> values = _productService.GetAll();
        return View(values);
    }
    [HttpGet]
    public IActionResult AddProductPage()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AddProductPage(Product p)
    {
        _productService.Add(p);
        return RedirectToAction("index");
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
