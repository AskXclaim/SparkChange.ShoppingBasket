namespace ShoppingBasket.Application.Features.Item.Queries.GetItemDetails;

public class GetItemWithDetailsQueryHandler : IRequestHandler<GetItemWithDetailsQuery, ItemDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IItemRepository _itemRepository;
    private readonly ICurrencyConverter _currencyConverter;

    public GetItemWithDetailsQueryHandler(IMapper mapper, IItemRepository itemRepository, ICurrencyConverter currencyConverter)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
        _currencyConverter = currencyConverter;
    }

    public async Task<ItemDetailsDto> Handle(GetItemWithDetailsQuery request, CancellationToken cancellationToken)
    {
        await FeaturesUtility.ValidateCurrencyCode(request.CurrencyCode);

        
        var item = await _itemRepository.GetItemWithDetails(request.Id);

        if (item == null)
                throw new NotFoundException(nameof(Domain.Item.Item), request.Id);

        var itemDetailsDto=  _mapper.Map<ItemDetailsDto>(item);

        if (string.IsNullOrWhiteSpace( item.CurrencyCode) ||
            item.CurrencyCode.Equals(request.CurrencyCode, StringComparison.OrdinalIgnoreCase)) return itemDetailsDto;
        
        var convertedPrice = await _currencyConverter.Convert(new CurrencyConverterRequest(itemDetailsDto.Price,
            item.CurrencyCode, request.CurrencyCode));
        itemDetailsDto.CurrencyCode = request.CurrencyCode;
         itemDetailsDto.Price = convertedPrice;

        return itemDetailsDto;
    }
}