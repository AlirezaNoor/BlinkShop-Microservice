using BlinkShop.Web.Models;
using BlinkShop.Web.Service.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace BlinkShop.Web.Controllers;
[Authorize]
public class ProductController:Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> ProductList(int? page)
    {
        int pageNumber = page ?? 1;
        int pageSize = 10;
  
        var list =await _productService.GetAll();
        var result = JsonConvert.DeserializeObject<List<ProductsDto>>(Convert.ToString(list.Result));
        IPagedList<ProductsDto> item = result.ToPagedList(pageNumber, pageSize);
        return View(item);
    }
}