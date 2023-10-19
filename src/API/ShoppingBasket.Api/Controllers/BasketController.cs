namespace ShoppingBasket.Api.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class BasketController : Controller
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public BasketController(IMediator mediator, IMapper mapper, IConfiguration configuration)
    {
        _mediator = mediator;
        _mapper = mapper;
        _configuration = configuration;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BasketItemModel>> GetItemFromBasket(int itemId, string? currencyCode,
        string basketKey)
    {
        currencyCode = ControllersUtility.GetCurrencyCode(_configuration, currencyCode);
        var basketItemDto = await _mediator.Send(new GetItemFromBasketQuery(itemId, currencyCode, basketKey));

        var basketItemModel = _mapper.Map<BasketItemModel>(basketItemDto);
        

        return Ok(basketItemModel);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult<BasketItemsModel>> GetAllItemsInBasket(string? currencyCode, string basketKey)
    {
        currencyCode = ControllersUtility.GetCurrencyCode(_configuration, currencyCode);
        var basketItemsDto = await _mediator.Send(new GetAllItemsFromBasketQuery(currencyCode, basketKey));
        var items = _mapper.Map<List<BasketItemModel>>(basketItemsDto);
        var basketItemsModel = new BasketItemsModel
        {
            Items = items,
            TotalPriceOfItems = items.Sum(i => i.TotalPrice)
        };

        return Ok(basketItemsModel);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> AddItemToBasket(string basketKey, int itemId, int quantity)
    {
        await _mediator.Send(new UpsertBasketCommand(basketKey, itemId, quantity));
        return CreatedAtAction(nameof(GetItemFromBasket), new {itemId, basketKey});
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> UpdateItemInBasket(string basketKey, int itemId, int quantity)
    {
        await _mediator.Send(new UpsertBasketCommand(basketKey, itemId, quantity));
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> RemoveItemFromBasket(string basketKey, int itemId)
    {
        await _mediator.Send(new RemoveItemFromBasketCommand(itemId, basketKey));
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> RemoveAllItemsFromBasket(string basketKey)
    {
        await _mediator.Send(new RemoveAllItemsFromBasketCommand(basketKey));
        return NoContent();
    }
}