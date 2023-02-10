namespace ShoppingBasket.Application.Features.Shared;

public static class FeaturesUtility
{
    public static async Task ValidateCurrencyCode(string currencyCode)
    {
        var validator = new CurrencyCodeValidator();
        var validationResult = await validator.ValidateAsync(currencyCode, default);
        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid request", validationResult);
    }
}