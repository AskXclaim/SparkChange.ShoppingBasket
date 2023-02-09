namespace ShoppingBasket.Application.Features.Basket.Commands.RemoveItems;

public class RemoveAllItemsFromBasketCommandHandler:IRequestHandler<RemoveAllItemsFromBasketCommand,Unit>
{
    private readonly IBasketRepository _basketRepository;

    public RemoveAllItemsFromBasketCommandHandler(IBasketRepository basketRepository)
    {
        _basketRepository = basketRepository;
    }
    public async Task<Unit> Handle(RemoveAllItemsFromBasketCommand request, CancellationToken cancellationToken)
    {
        await _basketRepository.RemoveAllItemFromBasketAsync( request.BasketKey);
        
        return Unit.Value;
    }
}