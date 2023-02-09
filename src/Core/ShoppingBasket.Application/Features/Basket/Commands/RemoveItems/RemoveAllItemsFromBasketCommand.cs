namespace ShoppingBasket.Application.Features.Basket.Commands.RemoveItems;

public record RemoveAllItemsFromBasketCommand( string BasketKey) : IRequest<Unit>;
