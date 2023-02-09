namespace ShoppingBasket.Persistence.Repositories.Item;

public class ItemRepository : IItemRepository
{
    private readonly ShoppingBasketDbContext _context;

    public ItemRepository(ShoppingBasketDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreatedAsync();
    }

    public async Task<Domain.Item.Item?> GetItemWithDetails(int itemId) =>
        await _context.Items.FirstOrDefaultAsync(i => i.Id == itemId);

    public async Task<List<Domain.Item.Item>> GetItems() => await _context.Items.ToListAsync();

    public async Task<bool> DoesItemExistAsync(int itemId) =>
        await _context.Items.AnyAsync(i => i.Id == itemId);
}