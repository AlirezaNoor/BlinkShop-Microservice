using BlinkShop.Web.Models;
using BlinkShop.Web.Service.IService;
using BlinkShop.Web.Utility;

namespace BlinkShop.Web.Service;

public class ProductService : IProductService
{
    private readonly IBaseService _baseService;
    private ResponseDto _responseDto;

    public ProductService(IBaseService baseService)
    {
        _baseService = baseService;
        _responseDto = new ResponseDto();
    }

    public async Task<ResponseDto?> GetAll()
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            url = SD.Product + "/Product",
        });
    }

    public async Task<ResponseDto?> GetById(int id)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            url = SD.Product + "/Product"+"/"+id,
        });
    }

    public async Task<ResponseDto?> Create(ProductsDto productsDto)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            url = SD.Product + "/Product" ,
            Data = productsDto
        });
    }

    public async Task<ResponseDto?> Update(ProductsDto productsDto)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            url = SD.Product + "/Product",
            Data = productsDto
        });
    }

    public async Task<ResponseDto?> Delete(int id)
    {
        return await _baseService.SendAsync(new RequestDto()
        {
            ApiType = SD.ApiType.GET,
            url = SD.Product + "/Product"+"/"+id,
        });
    }
}