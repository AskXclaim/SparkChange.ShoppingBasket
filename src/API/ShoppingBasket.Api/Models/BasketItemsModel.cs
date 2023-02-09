namespace ShoppingBasket.Api.Models;

public class BasketItemsModel
{
    public IEnumerable<BasketItemModel> Items { get; set; } = new List<BasketItemModel>();
    public decimal TotalPriceOfItems { get; set; }
}