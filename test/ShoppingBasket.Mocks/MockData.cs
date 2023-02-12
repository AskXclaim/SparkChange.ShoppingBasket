using ShoppingBasket.Api.Models.Basket;
using ShoppingBasket.Application.Features.Basket.Queries;
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

    public static BasketItemDto GetBasketItemDto() => new()
    {
        BasketKey = "BasketKey", CurrencyCode = "USD", ItemId = 1,
        Name = "Apple", Price = 0.90m, Quantity = 2
    };

    public static List<BasketItemDto> GetBasketItemsDto() => new()
    {
        new()
        {
            BasketKey = "BasketKey", CurrencyCode = "USD", ItemId = 1,
            Name = "Apple", Price = 0.90m, Quantity = 1
        },
        new()
        {
            BasketKey = "BasketKey", CurrencyCode = "USD", ItemId = 2,
            Name = "Soup", Price = 0.70m, Quantity = 2
        },
        new()
        {
            BasketKey = "BasketKey", CurrencyCode = "USD", ItemId = 2,
            Name = "Bread", Price = 0.80m, Quantity = 3
        }
    };
}