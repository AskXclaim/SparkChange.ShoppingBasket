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
    public async Task<ItemDetailsDto> GetItem(int itemId, string? currencyCode = "USD")
    {
        currencyCode = ControllersUtility.GetCurrencyCode(_configuration, currencyCode);

        var item = await _mediator.Send(new GetItemWithDetailsQuery(itemId, currencyCode.ToUpper()));

        return item;
    }


    [HttpGet("{currencyCode}")]
    public async Task<List<ItemDto>> GetAllItems(string? currencyCode = "USD")
    {
        currencyCode = ControllersUtility.GetCurrencyCode(_configuration, currencyCode);

        var items = await _mediator.Send(new GetItemsQuery(currencyCode));

        return items;
    }

    private string GetDefaultCurrency() => _configuration.GetValue<string>("DefaultCurrencyCode");
}