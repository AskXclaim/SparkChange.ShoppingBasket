namespace ShoppingBasket.Application.Features.Item.Queries.GetItemDetails;

public class ItemDetailsDto
{
    public int Id { get; set; }
    public string Name { get; set; }= string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public string? CurrencyCode { get; set; }=string.Empty;
}