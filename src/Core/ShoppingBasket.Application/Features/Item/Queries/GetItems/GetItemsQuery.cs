namespace ShoppingBasket.Application.Features.Item.Queries.GetItems;

public record GetItemsQuery(string CurrencyCode):IRequest<List<ItemDto>>;