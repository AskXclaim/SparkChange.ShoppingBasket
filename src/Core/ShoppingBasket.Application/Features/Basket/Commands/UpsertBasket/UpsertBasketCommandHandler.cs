namespace ShoppingBasket.Application.Features.Basket.Commands.UpsertBasket;

public class UpsertBasketCommandHandler:IRequestHandler<UpsertBasketCommand,string>
{
    private readonly IBasketRepository _basketRepository;
    private readonly IItemRepository _itemRepository;

    public UpsertBasketCommandHandler(IBasketRepository basketRepository, IItemRepository itemRepository)
    {
        _basketRepository = basketRepository;
        _itemRepository = itemRepository;
    }
    public async Task<string> Handle(UpsertBasketCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpsertBasketCommandValidator(_itemRepository);
       var validationResult= await validator.ValidateAsync(request, cancellationToken);

       if (validationResult.Errors.Any())
           throw new BadRequestException("Invalid request to add item to basket", validationResult);

       var item =await _itemRepository.GetItemWithDetails(request.ItemId);

       if (item == null)
           throw new NotFoundException($"{nameof(Domain.Item.Item)} with id {request.ItemId} not found");

       var basketRequest = new UpsertBasketItemRequest(request.ItemId, request.BasketKey,
           item.Name, "USD", item.Price, request.Quantity);

      return await _basketRepository.UpsertBasketItemAsync(basketRequest);
    }
}