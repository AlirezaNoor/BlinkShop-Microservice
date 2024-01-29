using BlinkShop.Web.Models;

namespace BlinkShop.Web.Service.IService;

public interface IProductService
{
    Task<ResponseDto?> GetAll();
    Task<ResponseDto> GetById(int id);
    Task<ResponseDto?> Create(ProductsDto productsDto);
    Task<ResponseDto> Update(ProductsDto productsDto);
    Task<ResponseDto?> Delete(int id);
    Task<ResponseDto?> GetAllForHomePage();
}