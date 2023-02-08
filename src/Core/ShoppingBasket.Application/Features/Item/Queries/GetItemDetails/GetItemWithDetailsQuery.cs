namespace ShoppingBasket.Application.Features.Item.Queries.GetItemDetails;

public record GetItemWithDetailsQuery(int Id):IRequest<ItemDetailsDto>;