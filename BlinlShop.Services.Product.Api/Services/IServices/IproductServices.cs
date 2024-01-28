using BlinlShop.Services.Product.Api.Model;

namespace BlinlShop.Services.Product.Api.Services.IServices;

public interface IproductServices
{
    Task<ResponseDto?> GetAll();
    Task<ResponseDto?> GetbyId(int id);
    Task<ResponseDto?> Create(Products porduct);
    Task<ResponseDto?> Update(Products products);
    Task<ResponseDto?> Delete(int id);
}