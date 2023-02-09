namespace ShoppingBasket.Application.Features.Basket.Queries.GetItem;

public class GetItemFromBasketQueryHandler : IRequestHandler<GetItemFromBasketQuery, BasketItemDto>
{
    private readonly IMapper _mapper;
    private readonly IBasketRepository _basketRepository;
    private readonly IItemRepository _itemRepository;

    public GetItemFromBasketQueryHandler(IMapper mapper, IBasketRepository basketRepository,
        IItemRepository itemRepository)
    {
        _mapper = mapper;
        _basketRepository = basketRepository;
        _itemRepository = itemRepository;
    }

    public async Task<BasketItemDto> Handle(GetItemFromBasketQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetItemFromBasketQueryValidator(_itemRepository);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid request", validationResult);

        var item = await _basketRepository.GetItemInBasket(request.BasketKey, request.ItemId);
        
        //Todo change it to match the requested currency if needs be

        return _mapper.Map<BasketItemDto>(item);
    }
}