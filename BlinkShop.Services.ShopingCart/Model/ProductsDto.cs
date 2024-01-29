namespace BlinkShop.Services.ShopingCart.Model;

public class ProductsDto
{
    public int id { get; set; }
    public string name { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string imgurl { get; set; }
    public double price     { get; set; }
}