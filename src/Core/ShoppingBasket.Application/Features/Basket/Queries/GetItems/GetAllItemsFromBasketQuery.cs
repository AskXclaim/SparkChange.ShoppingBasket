namespace ShoppingBasket.Application.Features.Basket.Queries.GetItems;

public record GetAllItemsFromBasketQuery(string CurrencyCode, string BasketKey):IRequest<List<BasketItemDto>>;