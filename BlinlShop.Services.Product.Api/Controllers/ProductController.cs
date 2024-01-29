using BlinlShop.Services.Product.Api.Model;
using BlinlShop.Services.Product.Api.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BlinlShop.Services.Product.Api.Controllers;

public class ProductController:BaseController
{
    private readonly IproductServices _services;

    public ProductController(IproductServices services)
    {
        _services = services;
    }

    [HttpGet] 
    public async Task<IActionResult> GetAll()
    {
        var reslt = await _services.GetAll();
        return Ok(reslt);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _services.GetbyId(id);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateProduct(ProductsDto product)
    {
        var Products = new Products()
        {
            name = product.name,
            Description = product.Description,
            imgurl = product.imgurl,
            price = product.price,
            CategoryName = product.CategoryName
        };
        var result=await _services.Create(Products);
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> UpdateProduct(ProductsDto product)
    {
 
        var Products = new Products()
        {
            id = product.id,
            name = product.name,
            Description = product.Description,
            imgurl = product.imgurl,
            price = product.price,
            CategoryName = product.CategoryName
        };
        var result=await _services.Create(Products);
        return Ok(result);
    }
    
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var result=await _services.Delete(id);
        return Ok(result);
    }
    
 
}