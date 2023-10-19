namespace ShoppingBasket.Api.Models.Basket;

public class BasketItemModel
{
    public int ItemId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string BasketKey { get; set; } = string.Empty;
    public string CurrencyCode { get; set; } = string.Empty;
    public string Coupon { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
}