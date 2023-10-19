namespace ShoppingBasket.Domain.Basket;

public class BasketItem :BaseEntity
{
    public int ItemId { get; set; }
    public int Quantity { get; set; }
    public string ShoppingBasketKey { get; set; } = string.Empty;
    public string Coupon { get; set; } = string.Empty;

}