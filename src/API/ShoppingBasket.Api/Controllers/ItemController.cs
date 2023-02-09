namespace ShoppingBasket.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemController : Controller
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;

    public ItemController(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<ItemDetailsDto> GetItem(int itemId, string currency = "USD")
    {
        if (string.IsNullOrWhiteSpace(currency)) currency = GetDefaultCurrency();

        var item = await _mediator.Send(new GetItemWithDetailsQuery(itemId));

        return item;
    }


    [HttpGet("{currency}")]
    public async Task<List<ItemDto>> GetAllItems(string currency = "USD")
    {
        if (string.IsNullOrWhiteSpace(currency)) currency = GetDefaultCurrency();

        var items = await _mediator.Send(new GetItemsQuery(currency));

        return items;
    }

    private string GetDefaultCurrency() => _configuration.GetValue<string>("DefaultCurrencyCode");
}