namespace ShoppingBasket.Application.Features.Basket.Commands.RemoveItem;

public record RemoveItemFromBasketCommand(int ItemId, string BasketKey) :IBasketBaseItem, IRequest<Unit>;
