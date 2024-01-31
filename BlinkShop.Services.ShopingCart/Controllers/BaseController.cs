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

 public async Task<IActionResult> UpsertCart(CartshopDto cd)
 {
  var CartHeaderFromDb = _myContext.CratHeaders.Where(x => x.id == cd.CratHeader.id);
  if (CartHeaderFromDb==null)
  {
   CartHeader cartHeader = new()
   {
    userid = cd.CratHeader.userid,
    discount = cd.CratHeader.discount,
    cartTotal = cd.CratHeader.cartTotal,
    CouponCode = cd.CratHeader.CouponCode
   };
   _myContext.CratHeaders.Add(cartHeader);
   await _myContext.SaveChangesAsync();
   cd.CardDtailesDtos.First().CardHeaderId = cartHeader.id;
   CardDtailes cardDtailes = new()
   {
    productId = cd.CardDtailesDtos.First().productId,
    Count = cd.CardDtailesDtos.First().Count,
    CardHeaderId = cd.CardDtailesDtos.First().CardHeaderId,
   };
   _myContext.CardDtailes.Add(cardDtailes);
   await _myContext.SaveChangesAsync();
  }
  else
  {
   var productinCart = _myContext.CardDtailes.Where(
    x => x.productId == cd.CardDtailesDtos.First().productId && x.CardHeaderId == CartHeaderFromDb.First().id
   );
   if (productinCart==null)
   {
    //create cartdetails
   }
   else
   {
   //AddCounter
   }


  }
  

 }
}