namespace ShoppingBasket.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<ItemDbContext>(options =>
            options.UseInMemoryDatabase("InMemoryItemsDatabase"));
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IItemRepository, ItemRepository>();
        return services;
    }
}