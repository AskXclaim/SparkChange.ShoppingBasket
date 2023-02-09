namespace ShoppingBasket.Application.Features.Basket.Queries.GetItem;

public class GetItemFromBasketQueryValidator: AbstractValidator<GetItemFromBasketQuery>
{
    public GetItemFromBasketQueryValidator(IItemRepository itemRepository)
    {
        Include(new BasketItemBaseValidator(itemRepository));
    }
}