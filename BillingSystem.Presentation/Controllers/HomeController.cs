using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BillingSystem.Presentation.Models;
using BillingSystem.BusinessLayer.Abstract;
using BillingSystem.EntityLayer.Concrete;
using BillingSystem.Presentation.Models.Dtos;

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

    CategoryWithProducts categoryWithProducts = new CategoryWithProducts();

    public IActionResult Index([FromRoute] int id = 0)
    {
        if (id.Equals(0))
        {
            categoryWithProducts.Categories = _categoryService.GetAll().Where(x => x.IsActive.Equals(true));
            categoryWithProducts.Products = _productService.GetAll().Where(y => y.IsActive.Equals(true)).OrderByDescending(x => x.ProductId);

        }
        else
        {
            categoryWithProducts.Categories = _categoryService.GetAll().Where(x => x.IsActive.Equals(true));
            categoryWithProducts.Products = _productService.GetAll().Where(x => x.CategoryId.Equals(id)).Where(y => y.IsActive.Equals(true)).OrderByDescending(x => x.ProductId);
        }
        return View(categoryWithProducts);
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
