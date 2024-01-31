namespace BlinkShop.Services.ShopingCart.Model;

public class CardDtailesDto
{
    public int CardDtailesId { get; set; }
    public int  CardHeaderId { get; set; }
    public int  productId { get; set; }
    public int Count { get; set; }
    public CartHeader? cartheader { get; set; }
    public ProductsDto? product { get; set; }
}