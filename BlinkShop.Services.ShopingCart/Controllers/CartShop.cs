using BlinkShop.Services.ShopingCart.Context.CartShopDbContext;
using BlinkShop.Services.ShopingCart.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlinkShop.Services.ShopingCart.Controllers;

[ApiController]
[Route("[controller]")]
public class CartShop : ControllerBase
{
    private readonly MyContext _myContext;
    private ResponseDto _responseDto;

    public CartShop(MyContext myContext)
    {
        _myContext = myContext;
        _responseDto = new ResponseDto();
    }

    [HttpPost]
    public async Task<IActionResult> UpsertCart(CartshopDto cd)
    {
        try
        {
            var CartHeaderFromDb = await _myContext.CratHeaders.AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == cd.CratHeader.id);
            if (CartHeaderFromDb == null)
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
                var productinCart = await _myContext.CardDtailes.AsNoTracking().FirstOrDefaultAsync(
                    x => x.productId == cd.CardDtailesDtos.First().productId &&
                         x.CardHeaderId == CartHeaderFromDb.id
                );
                if (productinCart == null)
                {
                    CardDtailes cardDtailes = new()
                    {
                        productId = cd.CardDtailesDtos.First().productId,
                        Count = cd.CardDtailesDtos.First().Count,
                        CardHeaderId = CartHeaderFromDb.id,
                    };
                    _myContext.CardDtailes.Add(cardDtailes);
                    await _myContext.SaveChangesAsync();
                }
                else
                {
                    cd.CardDtailesDtos.First().Count += productinCart.Count;
                    cd.CardDtailesDtos.First().CardHeaderId = CartHeaderFromDb.id;
                    cd.CardDtailesDtos.First().CardDtailesId = productinCart.CardDtailesId;

                    CardDtailes cardDtailes = new()
                    {
                        productId = cd.CardDtailesDtos.First().productId,
                        Count = cd.CardDtailesDtos.First().Count,
                        CardHeaderId = CartHeaderFromDb.id,
                    };
                    _myContext.CardDtailes.Add(cardDtailes);
                    await _myContext.SaveChangesAsync();
                }

                _responseDto.Result = cd;
            }
        }
        catch (Exception e)
        {
            _responseDto.Success = false;
            _responseDto.Massege = e.Message;
        }

        return Ok(_responseDto);
    }

    [HttpPost("delete")]
    public async Task<IActionResult> Remove([FromBody] int CardDetailsId)
    {
        try
        {
            var cartDtailesFromDb = await _myContext.CardDtailes.AsNoTracking()
                .FirstOrDefaultAsync(x => x.CardDtailesId == CardDetailsId);
            var cart = _myContext.CardDtailes.Where(x => x.CardHeaderId == cartDtailesFromDb.CardHeaderId).Count();
            _myContext.CardDtailes.Remove(cartDtailesFromDb);

            if (cart == 1)
            {
                var cardheader =
                    await _myContext.CratHeaders.FirstOrDefaultAsync(x => x.id == cartDtailesFromDb.CardHeaderId);
                _myContext.CratHeaders.Remove(cardheader);
            }

            await _myContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            _responseDto.Success = false;
            _responseDto.Massege = e.Message;
        }

        return Ok(_responseDto);
    }

    [HttpGet]
    public async Task<IActionResult> GetUserCart(string userid)
    {
        try
        {
            var ch = _myContext.CratHeaders.First(x => x.userid == userid);
            CratHeaderDto carthedardt0 = new()
            {
                userid = ch.userid,
                discount = ch.discount,
                CouponCode = ch.CouponCode,
                id = ch.id
            };
            var cd = _myContext.CardDtailes.Where(x => x.CardHeaderId == ch.id).Select(x => new CardDtailesDto()
            {
                productId = x.productId,
                Count = x.Count,
                CardHeaderId = x.CardHeaderId,
                CardDtailesId = x.CardDtailesId,
                product = x.product,
                cartheader = x.cartheader
            }).ToList();

            CartshopDto cart = new CartshopDto()
            {
                CratHeader = carthedardt0,
                CardDtailesDtos = cd
            };
            foreach (var i in cart.CardDtailesDtos)
            {
                cart.CratHeader.cartTotal += i.Count * i.product.price;
            }

            _responseDto.Result = cart;
        }
        catch (Exception e)
        {
            _responseDto.Success = false;
            _responseDto.Massege = e.Message;
        }
        return Ok(_responseDto);
    }
}