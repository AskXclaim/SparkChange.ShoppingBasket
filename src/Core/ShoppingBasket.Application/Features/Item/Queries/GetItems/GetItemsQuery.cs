namespace ShoppingBasket.Application.Features.Item.Queries.GetItems;

public record GetItemsQuery(string Currency):IRequest<List<ItemDto>>;