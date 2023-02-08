namespace ShoppingBasket.Application.Features.Item.Queries.GetItemDetails;

public class GetItemWithDetailsQueryHandler:IRequestHandler<GetItemWithDetailsQuery, ItemDetailsDto>
{
    private readonly IMapper _mapper;
    private readonly IItemRepository _itemRepository;

    public GetItemWithDetailsQueryHandler(IMapper mapper, IItemRepository itemRepository)
    {
        _mapper = mapper;
        _itemRepository = itemRepository;
    }
    public async Task<ItemDetailsDto> Handle(GetItemWithDetailsQuery request, CancellationToken cancellationToken)
    {
        var item =await _itemRepository.GetAsync(request.Id);

        if (item == null)
            throw new NotFoundException(nameof(Domain.Item.Item), request.Id);
        
        return _mapper.Map<ItemDetailsDto>(item);
    }

}