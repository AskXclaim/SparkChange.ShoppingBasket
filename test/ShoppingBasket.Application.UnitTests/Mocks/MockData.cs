using ShoppingBasket.Domain.Item;

namespace ShoppingBasket.Application.UnitTests.Mocks;

public static class MockData
{
    public static Item GetItem() => new()
    {
        Id = 1, Name = "Apples", Description = "Description", CurrencyCode = "USD", Price = 1.00m
    };
}