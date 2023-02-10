using ShoppingBasket.Application.Features.Item.Queries.GetItemDetails;
using ShoppingBasket.Application.Features.Item.Queries.GetItems;
using ShoppingBasket.Domain.Item;

namespace ShoppingBasket.MockData;

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

    public static ItemDetailsDto GetItemDetailsDto() => new ItemDetailsDto()
    {
        Id = 1, Name = "Apples", Description = "Juicy Apples", CurrencyCode = "USD", Price = 1m
    };

    public static List<ItemDto> GeItemDtos()
    {
        return new List<ItemDto>()
        {
            new()
            {
                Id = 1, Name = "Soup", CurrencyCode = "USD", Price = 1.3m
            },
            new()
            {
                Id = 2, Name = "Bread", CurrencyCode = "USD", Price = 0.7m
            },
            new()
            {
                Id = 3, Name = "Banana", CurrencyCode = "USD", Price = 0.9m
            },
        };
    }
}