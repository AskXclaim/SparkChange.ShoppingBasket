namespace ShoppingBasket.Application.Contracts.Persistence.Basket;

public interface IBasketRepository
{
    Task<BasketItem?> GetItemInBasket(string basketKey,int itemId);
    Task<List<BasketItem>> GetItemsInBasket(string basketKey,string currencyCode);
    Task<string> UpsertBasketItemAsync(UpsertBasketItemRequest request);
    Task RemoveItemFromBasketAsync(int itemId, string basketKey);
    Task RemoveAllItemFromBasketAsync(string basketKey);
}