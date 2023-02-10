namespace ShoppingBasket.Application.Features.Basket.Queries.GetBasketItem;

public record GetItemFromBasketQuery( int ItemId, string CurrencyCode, string BasketKey):IBasketBaseItem, IRequest<BasketItemDto>;