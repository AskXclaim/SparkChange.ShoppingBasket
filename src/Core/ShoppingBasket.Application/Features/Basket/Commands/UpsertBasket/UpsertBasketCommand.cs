namespace ShoppingBasket.Application.Features.Basket.Commands.UpsertBasket;

public record UpsertBasketCommand(string BasketKey, int ItemId, int Quantity):IBasketBaseItem, IRequest<string>;