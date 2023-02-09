namespace ShoppingBasket.Application.Features.Basket.Commands.RemoveItem;

public class RemoveItemFromBasketCommandHandler:IRequestHandler<RemoveItemFromBasketCommand,Unit>
{
    private readonly IBasketRepository _basketRepository;
    private readonly IItemRepository _itemRepository;

    public RemoveItemFromBasketCommandHandler(IBasketRepository basketRepository, IItemRepository itemRepository)
    {
        _basketRepository = basketRepository;
        _itemRepository = itemRepository;
    }
    public async Task<Unit> Handle(RemoveItemFromBasketCommand request, CancellationToken cancellationToken)
    {
        var validator = new BasketItemBaseValidator(_itemRepository);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid request to remove an item from the basket", validationResult);

        await _basketRepository.RemoveItemFromBasketAsync(request.ItemId, request.BasketKey);
        
        return Unit.Value;

    }
}