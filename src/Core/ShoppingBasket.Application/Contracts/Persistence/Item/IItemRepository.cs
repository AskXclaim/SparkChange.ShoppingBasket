namespace ShoppingBasket.Application.Contracts.Persistence.Item;

public interface IItemRepository
{
    Task<Domain.Item.Item?> GetItemWithDetails(int itemId);
    Task<List<Domain.Item.Item>> GetItems();
    Task<bool> DoesItemExistAsync(int itemId);
}