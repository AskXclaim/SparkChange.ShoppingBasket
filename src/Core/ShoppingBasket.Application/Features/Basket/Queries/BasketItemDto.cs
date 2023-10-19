namespace ShoppingBasket.Application.Features.Basket.Queries;

public class BasketItemDto
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string BasketKey { get; set; } = string.Empty;
    public decimal TotalPrice { get; set; }
    public string CurrencyCode { get; set; } = string.Empty;
}