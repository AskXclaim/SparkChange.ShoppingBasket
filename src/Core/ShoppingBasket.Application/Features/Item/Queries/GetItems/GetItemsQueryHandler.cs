namespace ShoppingBasket.Application.Features.Item.Queries.GetItems;

public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, List<ItemDto>>
{
    private readonly IMapper _mapper;
    private readonly IItemRepository _itemRepository;
    private readonly ICurrencyConverter _currencyConverter;

    public GetItemsQueryHandler(IMapper mapper, IItemRepository itemRepository, ICurrencyConverter currencyConverter)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
        _currencyConverter = currencyConverter;
    }

    public async Task<List<ItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
       await FeaturesUtility.ValidateCurrencyCode(request.CurrencyCode);

       var items = await _itemRepository.GetItems();
        if (items == null)
            throw new NotFoundException($"No {nameof(Domain.Item.Item)}s found");

        var itemsDto = new List<ItemDto>();
        foreach (var item in items)
        {
            if (string.IsNullOrWhiteSpace(item.CurrencyCode) ||
                item.CurrencyCode.Equals(request.CurrencyCode, StringComparison.OrdinalIgnoreCase))
            {
                itemsDto.Add(_mapper.Map<ItemDto>(item));
            }
            else
            {
                var convertedPrice = await _currencyConverter.Convert(new CurrencyConverterRequest(item.Price,
                    item.CurrencyCode, request.CurrencyCode));
                itemsDto.Add(new ItemDto()
                {
                    Id = item.Id, Name = item.Name, CurrencyCode = request.CurrencyCode, Price = convertedPrice
                });
            }
        }

        return itemsDto;
    }
}