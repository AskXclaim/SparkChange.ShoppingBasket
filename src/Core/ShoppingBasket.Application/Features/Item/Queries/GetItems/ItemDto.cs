namespace ShoppingBasket.Application.Features.Item.Queries.GetItems;

public class ItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }= string.Empty;
    public decimal Price { get; set; }
    public string? CurrencyCode { get; set; }=string.Empty;
}