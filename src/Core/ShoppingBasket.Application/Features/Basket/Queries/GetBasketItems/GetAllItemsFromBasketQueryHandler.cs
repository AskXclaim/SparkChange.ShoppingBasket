namespace ShoppingBasket.Application.Features.Basket.Queries.GetBasketItems;

public class GetAllItemsFromBasketQueryHandler : IRequestHandler<GetAllItemsFromBasketQuery, List<BasketItemDto>>
{
    private readonly IMapper _mapper;
    private readonly IBasketRepository _basketRepository;
    private readonly ICurrencyConverter _currencyConverter;

    public GetAllItemsFromBasketQueryHandler(IMapper mapper, IBasketRepository basketRepository,
        ICurrencyConverter currencyConverter)
    {
        _mapper = mapper;
        _basketRepository = basketRepository;
        _currencyConverter = currencyConverter;
    }

    public async Task<List<BasketItemDto>> Handle(GetAllItemsFromBasketQuery request,
        CancellationToken cancellationToken)
    {
        await FeaturesUtility.ValidateCurrencyCode(request.CurrencyCode);

        var basketItems = await _basketRepository.GetItemsInBasket(request.BasketKey, request.CurrencyCode);
        if (basketItems == null)
            throw new NotFoundException($"No {nameof(BasketItem)}s found");

        var basketItemsDto = new List<BasketItemDto>();
        foreach (var basketItem in basketItems)
        {
            if (string.IsNullOrWhiteSpace(basketItem.CurrencyCode) ||
                basketItem.CurrencyCode.Equals(request.CurrencyCode, StringComparison.OrdinalIgnoreCase))
            {
                basketItemsDto.Add(_mapper.Map<BasketItemDto>(basketItem));
            }
            else
            {
                var convertedPrice = await _currencyConverter.Convert(new CurrencyConverterRequest(basketItem.Price,
                    basketItem.CurrencyCode, request.CurrencyCode));
                basketItemsDto.Add(new BasketItemDto()
                {
                    Id = basketItem.Id, ItemId = basketItem.ItemId, Name = basketItem.Name,
                    CurrencyCode = request.CurrencyCode, Price = convertedPrice
                });
            }
        }

        return basketItemsDto;
    }
}