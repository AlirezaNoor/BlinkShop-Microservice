namespace BlinkShop.Web.Models;

public class ResponseDto
{
    public object? Result { get; set; }
    public bool Success { get; set; } = true;
    public string Massege { get; set; } = " ";
}