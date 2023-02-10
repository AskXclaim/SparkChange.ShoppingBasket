namespace ShoppingBasket.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpClient();
        services.Configure<CurrencyConverterSettings>(configuration.GetSection("CurrencyConverterSettings"));
        services.AddScoped<ICurrencyConverter, CurrencyConverter.CurrencyConverter>();
        return services;
    }
}