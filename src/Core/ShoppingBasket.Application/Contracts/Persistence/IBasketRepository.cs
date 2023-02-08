namespace ShoppingBasket.Application.Contracts.Persistence;

public interface IBasketRepository:IGenericRepository<Basket>
{
    Task UpdateBasketItemAsync(int id, int quantity);
    Task RemoveItemFromBasketAsync(int id);
    Task RemoveAllItemFromBasketAsync();
}