using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace BlinkShop.Services.ShopingCart.Model;

public class CardDtailes
{
    [Key] public int CardDtailesId { get; set; }
    public int CardHeaderId { get; set; }
    public int productId { get; set; }
    public int Count { get; set; }
    [ForeignKey("CardHeaderId")] public CratHeader cartheader { get; set; }
    [NotMapped] public ProductsDto product { get; set; }
}