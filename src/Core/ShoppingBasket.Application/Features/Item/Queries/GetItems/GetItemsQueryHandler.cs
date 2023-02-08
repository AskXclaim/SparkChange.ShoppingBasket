namespace ShoppingBasket.Application.Features.Item.Queries.GetItems;

public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, List<ItemDto>>
{
    private readonly IMapper _mapper;
    private readonly IItemRepository _itemRepository;

    public GetItemsQueryHandler(IMapper mapper, IItemRepository itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }

    public async Task<List<ItemDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
    {
        var items = await _itemRepository.GetAllAsync();

        if (items == null)
            throw new NotFoundException($"No {nameof(Domain.Item.Item)}s found");

        return _mapper.Map<List<ItemDto>>(items);
    }
}