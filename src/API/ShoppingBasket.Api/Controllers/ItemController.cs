namespace ShoppingBasket.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ItemController : Controller
{
    private readonly IMediator _mediator;

    public ItemController( IMediator mediator)=> _mediator = mediator;
    
    [HttpGet]
    public async Task<List<ItemDto>> GetAllItems()
    {
        var items = await _mediator.Send(new GetItemsQuery());

        return items;
    }
}