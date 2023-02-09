namespace ShoppingBasket.Application.Features.Basket.Queries.GetItem;

public record GetItemFromBasketQuery( int ItemId, string CurrencyCode, string BasketKey):IBasketBaseItem, IRequest<BasketItemDto>;