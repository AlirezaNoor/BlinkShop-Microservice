namespace BlinkShop.Services.ShopingCart.Model;


public class ResponseDto
{
    public object? Result { get; set; }
    public bool Success { get; set; } = true;
    public string Massege { get; set; } = " ";
}