namespace BlinkShop.Services.ShopingCart.Model;

public class CartshopDto
{
    public CratHeaderDto CratHeader { get; set; }
    public IEnumerable<CardDtailesDto>? CardDtailesDtos { get; set; }
}