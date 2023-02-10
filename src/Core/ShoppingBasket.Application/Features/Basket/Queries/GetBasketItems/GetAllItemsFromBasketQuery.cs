namespace ShoppingBasket.Application.Features.Basket.Queries.GetBasketItems;

public record GetAllItemsFromBasketQuery(string CurrencyCode, string BasketKey):IRequest<List<BasketItemDto>>;