namespace ShoppingBasket.Api.Shared;

public static class ControllersUtility
{
    public static string GetCurrencyCode(IConfiguration configuration, string currencyCode)
    {
        if (string.IsNullOrWhiteSpace(currencyCode))
            currencyCode = configuration.GetValue<string>("DefaultCurrencyCode");
        
        return currencyCode;
    }
}