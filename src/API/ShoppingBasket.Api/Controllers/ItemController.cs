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
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<ItemDetailsDto>> GetItem(int itemId, string? currencyCode = "USD")
    {
        currencyCode = ControllersUtility.GetCurrencyCode(_configuration, currencyCode);

        var item = await _mediator.Send(new GetItemWithDetailsQuery(itemId, currencyCode.ToUpper()));

        return Ok(item);
    }


    [HttpGet("{currencyCode}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<List<ItemDto>>> GetAllItems(string? currencyCode = "USD")
    {
        currencyCode = ControllersUtility.GetCurrencyCode(_configuration, currencyCode);

        var items = await _mediator.Send(new GetItemsQuery(currencyCode));

        return Ok(items);
    }
}