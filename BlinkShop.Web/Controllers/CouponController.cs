using BlinkShop.Web.Models;
using BlinkShop.Web.Service.IService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlinkShop.Web.Controllers;

public class CouponController:Controller
{
    private readonly ICouponService _couponService;

    public CouponController(ICouponService couponService)
    {
        _couponService = couponService;
    }
    [HttpGet]
    public async Task<IActionResult> CouponGetAll()
    {
        List<CouponDto> list = new();
        var response=await _couponService.GetAll();
        if (response!=null && response.Success)
        {
            list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
        }

        return View(list);
    }
}