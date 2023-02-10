namespace ShoppingBasket.Application.Features.Basket.Common;

public class BasketItemBaseValidator:AbstractValidator<IBasketBaseItem>
{
    private readonly IItemRepository _itemRepository;

    public BasketItemBaseValidator(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
        RuleFor(i => i.ItemId)
            .NotEmpty()
            .WithMessage("{PropertyName} must be present");
        RuleFor(i => i)
            .MustAsync(DoesItemExist)
            .WithMessage($"Item does not exist");
    }

    private async Task<bool> DoesItemExist(IBasketBaseItem item, CancellationToken token)
        =>  await _itemRepository.DoesItemExistAsync(item.ItemId);
}