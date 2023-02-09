namespace ShoppingBasket.Application.Features.Basket.Queries.GetItems;

public class GetAllItemsFromBasketQueryHandler : IRequestHandler<GetAllItemsFromBasketQuery, List<BasketItemDto>>
{
    private readonly IMapper _mapper;
    private readonly IBasketRepository _basketRepository;

    public GetAllItemsFromBasketQueryHandler(IMapper mapper, IBasketRepository basketRepository)
    {
        _mapper = mapper;
        _basketRepository = basketRepository;
    }

    public async Task<List<BasketItemDto>> Handle(GetAllItemsFromBasketQuery request, CancellationToken cancellationToken)
    {
        var item = await _basketRepository.GetItemsInBasket(request.BasketKey, request.CurrencyCode);
        
        //Todo change it to match the requested currency if needs be

        return _mapper.Map<List<BasketItemDto>>(item);
    }
}