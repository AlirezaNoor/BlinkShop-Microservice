using BlinlShop.Services.Product.Api.Context;
using BlinlShop.Services.Product.Api.Model;

namespace BlinlShop.Services.Product.Api.Services.IServices;

public class productServices : IproductServices
{
    private readonly myDbContext _service;
    private readonly ResponseDto _responseDto;

    public productServices(myDbContext service)
    {
        _service = service;
        _responseDto = new ResponseDto();
    }

    public async Task<ResponseDto?> GetAll()
    {
        try
        {
            _responseDto.Success = true;
            _responseDto.Result = _service.Products.ToList();
            return _responseDto;
        }
        catch (Exception e)
        {
            _responseDto.Success = false;
            _responseDto.Massege = e.Message;
            return _responseDto;
        }
    }

    public async Task<ResponseDto?> GetbyId(int id)
    {
        try
        {
            _responseDto.Success = true;
            _responseDto.Result = _service.Products.FirstOrDefault(x => x.id == id);
            return _responseDto;
        }
        catch (Exception e)
        {
            _responseDto.Success = false;
            _responseDto.Massege = e.Message;
            return _responseDto;
        }
    }

    public async Task<ResponseDto?> Create(Products porduct)
    {
        try
        {
            var result = _service.Add(porduct);
            await _service.SaveChangesAsync();
            _responseDto.Success = true;
            _responseDto.Result = result.Entity;

            return _responseDto;
        }
        catch (Exception e)
        {
            _responseDto.Success = false;
            _responseDto.Massege = e.Message;
            return _responseDto;
        }
    }

    public async Task<ResponseDto?> Update(Products products)
    {
        try
        {
            var test = _service.Products.Update(products);
            await _service.SaveChangesAsync();
            _responseDto.Success = true;
            _responseDto.Result = test.Entity;
            return _responseDto;
        }
        catch (Exception e)
        {
            _responseDto.Success = false;
            _responseDto.Massege = e.Message;
            return _responseDto;
        }
    }

    public async Task<ResponseDto?> Delete(int id)
    {
        try
        {
            var product = _service.Products.First(x => x.id == id);
            var test = _service.Products.Remove(product);
            await _service.SaveChangesAsync();
            _responseDto.Success = true;
            _responseDto.Result = test.Entity;
            return _responseDto;
        }
        catch (Exception e)
        {
            _responseDto.Success = false;
            _responseDto.Massege = e.Message;
            return _responseDto;
        }
     
    }
}