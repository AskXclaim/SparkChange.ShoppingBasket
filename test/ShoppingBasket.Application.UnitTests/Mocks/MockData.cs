using ShoppingBasket.Domain.Item;

namespace ShoppingBasket.Application.UnitTests.Mocks;

public static class MockData
{
    public static Item GetItem() => new()
    {
        Id = 1, Name = "Apples", Description = "Description", CurrencyCode = "USD", Price = 1.00m
    };
    
    public static List<Item> GetItems() => new()
    {
        new Item()
        {
            Id = 1, Name = "Apples", Description = "Description", CurrencyCode = "USD", Price = 1.00m
        },
        new Item()
        {
            Id = 2, Name = "Soup", Description = "Description", CurrencyCode = "USD", Price = .70m,
        },
        new Item()
        {
            Id = 3, Name = "Berries", Description = "Description", CurrencyCode = "USD", Price = 1.10m,
        }
    };
}