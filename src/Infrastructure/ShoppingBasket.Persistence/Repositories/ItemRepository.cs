namespace ShoppingBasket.Persistence.Repositories;

public class ItemRepository:GenericRepository<Item>, IItemRepository
{
    public ItemRepository(ItemDbContext context) : base(context)
    {
    }
}