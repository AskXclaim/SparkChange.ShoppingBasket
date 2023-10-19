namespace ShoppingBasket.Application.Features.Basket.Queries.GetBasketItem;

public class GetItemFromBasketQueryHandler : IRequestHandler<GetItemFromBasketQuery, BasketItemDto>
{
    private readonly IMapper _mapper;
    private readonly IBasketRepository _basketRepository;
    private readonly IItemRepository _itemRepository;
    private readonly ICurrencyConverter _currencyConverter;

    public GetItemFromBasketQueryHandler(IMapper mapper, IBasketRepository basketRepository,
        IItemRepository itemRepository, ICurrencyConverter currencyConverter)
    {
        _mapper = mapper;
        _basketRepository = basketRepository;
        _itemRepository = itemRepository;
        _currencyConverter = currencyConverter;
    }

    public async Task<BasketItemDto> Handle(GetItemFromBasketQuery request, CancellationToken cancellationToken)
    {
        await FeaturesUtility.ValidateCurrencyCode(request.CurrencyCode);
        var validator = new GetItemFromBasketQueryValidator(_itemRepository);
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid request", validationResult);

        var item = await _basketRepository.GetItemInBasket(request.BasketKey, request.ItemId);
        if (item == null)
            throw new NotFoundException(nameof(Domain.Item.Item), request.ItemId);

        var basketItemDto=  _mapper.Map<BasketItemDto>(item);
        
        if (string.IsNullOrWhiteSpace( item.CurrencyCode) ||
            item.CurrencyCode.Equals(request.CurrencyCode, StringComparison.OrdinalIgnoreCase)) return basketItemDto;
        
        var convertedPrice = await _currencyConverter.Convert(new CurrencyConverterRequest(basketItemDto.Price,
            item.CurrencyCode, request.CurrencyCode));
        basketItemDto.CurrencyCode = request.CurrencyCode;
        basketItemDto.Price = convertedPrice;

        if (!string.IsNullOrWhiteSpace(item.Coupon))
        {
            //Get new total price 
            basketItemDto.TotalPrice = 0M;  // Fit new total price
        }

        return basketItemDto;
    }
}