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

    [HttpGet]
    public async Task<IActionResult> CreateCoupon()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCoupon(CouponDto couponDto)
    {
      
            var create =await _couponService.Create(couponDto);
            if (create!=null && create.Success)
            {
                var result = JsonConvert.DeserializeObject<CouponDto>(Convert.ToString(create.Result));
                ViewBag.Message = "عملیات با موفقیت انجام شد";
                return View(couponDto);

            }
            ViewBag.Message = "عملیات با خطا  مواجه شد  ";
            
        return View();
    }
}