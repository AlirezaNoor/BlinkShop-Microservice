using BlinkShop.Services.ShopingCart.Context.CartShopDbContext;
using BlinkShop.Services.ShopingCart.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlinkShop.Services.ShopingCart.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController : ControllerBase
{
 private readonly MyContext _myContext;
 private ResponseDto _responseDto;

 public BaseController(MyContext myContext)
 {
  _myContext = myContext;
  _responseDto = new ResponseDto();
 }
 
 
}