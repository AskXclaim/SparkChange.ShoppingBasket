namespace ShoppingBasket.Application.Contracts.Persistence.Basket;

public record UpsertBasketItemRequest(int ItemId, string ShoppingBasketKey, string Name,
    string CurrencyCode, decimal Price, int Quantity);