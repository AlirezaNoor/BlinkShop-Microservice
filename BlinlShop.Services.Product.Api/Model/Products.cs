namespace BlinlShop.Services.Product.Api.Model;

public class Products
{
    public int id { get; set; }
    public string name { get; set; }
    public string Description { get; set; }
    public string CategoryName { get; set; }
    public string imgurl { get; set; }
    public double price     { get; set; }
}