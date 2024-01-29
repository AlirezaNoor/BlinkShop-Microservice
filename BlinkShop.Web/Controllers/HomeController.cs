using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BlinkShop.Web.Models;
using BlinkShop.Web.Service.IService;
using Newtonsoft.Json;

namespace BlinkShop.Web.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProductService _productService;

    public HomeController(ILogger<HomeController> logger, IProductService productService)
    {
        _logger = logger;
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var list =await _productService.GetAllForHomePage();
        var result = JsonConvert.DeserializeObject<List<ProductsDto>>(Convert.ToString(list.Result));
        return View(result);
    }
    public async Task<IActionResult> Details(int id)
    {
        var list =await _productService.GetById(id);
        var result = JsonConvert.DeserializeObject<ProductsDto>(Convert.ToString(list.Result));
        return View(result);
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