namespace ShoppingBasket.Application.Features.Basket.Queries.GetBasketItem;

public class GetItemFromBasketQueryValidator: AbstractValidator<GetItemFromBasketQuery>
{
    public GetItemFromBasketQueryValidator(IItemRepository itemRepository)
    {
        Include(new BasketItemBaseValidator(itemRepository));
    }
}