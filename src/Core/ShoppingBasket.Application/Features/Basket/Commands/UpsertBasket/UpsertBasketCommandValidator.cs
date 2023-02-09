namespace ShoppingBasket.Application.Features.Basket.Commands.UpsertBasket;

public class UpsertBasketCommandValidator : AbstractValidator<UpsertBasketCommand>
{
    public UpsertBasketCommandValidator(IItemRepository itemRepository)
    {
        Include(new BasketItemBaseValidator(itemRepository));
        RuleFor(bi => bi.Quantity)
            .GreaterThanOrEqualTo(0)
            .WithMessage("{PropertyName} must be greater than {ComparisonValue}");
    }
}