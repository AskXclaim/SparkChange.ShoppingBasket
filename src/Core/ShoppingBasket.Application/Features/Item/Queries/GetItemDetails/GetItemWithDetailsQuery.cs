namespace ShoppingBasket.Application.Features.Item.Queries.GetItemDetails;

public record GetItemWithDetailsQuery(int Id, string CurrencyCode):IRequest<ItemDetailsDto>;