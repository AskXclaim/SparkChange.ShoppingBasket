namespace ShoppingBasket.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<ShoppingBasketDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryItemsDatabase"));
        services.AddScoped<IItemRepository, ItemRepository>();
        services.AddScoped<IBasketRepository, BasketRepository>();
        return services;
    }
}