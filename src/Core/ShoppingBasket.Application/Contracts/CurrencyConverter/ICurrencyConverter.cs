namespace ShoppingBasket.Application.Contracts.CurrencyConverter;

public interface ICurrencyConverter
{
    Task<decimal> Convert(CurrencyConverterRequest request);
}