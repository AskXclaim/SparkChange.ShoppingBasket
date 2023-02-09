namespace ShoppingBasket.Persistence.Repositories.Basket;

public class BasketRepository : IBasketRepository
{
    private readonly ShoppingBasketDbContext _context;

    public BasketRepository(ShoppingBasketDbContext context)
    {
        _context = context;
    }

    public async Task<BasketItem?> GetItemInBasket(string basketKey, int itemId) =>
        await _context.BasketItems.AsNoTracking().FirstOrDefaultAsync(
            bi => bi.ShoppingBasketKey == basketKey && bi.Id == itemId);

    public async Task<List<BasketItem>> GetItemsInBasket(string basketKey, string currencyCode) =>
        await _context.BasketItems.AsNoTracking().Where(bi => bi.ShoppingBasketKey == basketKey).ToListAsync();

    public async Task<string> UpsertBasketItemAsync(UpsertBasketItemRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.ShoppingBasketKey) && request.Quantity > 0)
        {
            var basketKey = Guid.NewGuid().ToString();

            await _context.BasketItems.AddAsync(GetBasketItem(request, basketKey));

            return basketKey;
        }

        if (request.Quantity == 0)
            await RemoveItemFromBasketAsync(request.ItemId, request.ShoppingBasketKey);

        var isAvailable = await _context.BasketItems.AnyAsync(
                bi => bi.ShoppingBasketKey == request.ShoppingBasketKey && bi.Id == request.ItemId);
        if (isAvailable)
        {
            _context.BasketItems.Update(GetBasketItem(request, request.ShoppingBasketKey));
        }
        else
        {
            await _context.BasketItems.AddAsync(GetBasketItem(request, request.ShoppingBasketKey));
        }

        await _context.SaveChangesAsync();

        return request.ShoppingBasketKey;
    }

    private BasketItem GetBasketItem(UpsertBasketItemRequest request, string basketKey)
        => new()
        {
            Id = request.ItemId, ShoppingBasketKey = basketKey,
            CurrencyCode = request.CurrencyCode, Quantity = request.Quantity,
            Name = request.Name, Price = request.Price
        };


    public async Task RemoveItemFromBasketAsync(int itemId, string basketKey)
    {
        var itemToRemove = await _context.BasketItems.FirstOrDefaultAsync(bi =>
            bi.Id == itemId && bi.ShoppingBasketKey == basketKey);

        if (itemToRemove != null) _context.BasketItems.Remove(itemToRemove);

        await _context.SaveChangesAsync();
    }

    public async Task RemoveAllItemFromBasketAsync(string basketKey)
    {
        var basketItems = _context.BasketItems
            .Where(bi => bi.ShoppingBasketKey == basketKey);
        _context.BasketItems.RemoveRange(basketItems);
        await _context.SaveChangesAsync();
    }
}