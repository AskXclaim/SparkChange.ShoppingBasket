namespace ShoppingBasket.Domain.Basket;

public class BasketItem :BaseEntity
{
    public int Quantity { get; set; }
    public string ShoppingBasketKey { get; set; } = string.Empty;

}