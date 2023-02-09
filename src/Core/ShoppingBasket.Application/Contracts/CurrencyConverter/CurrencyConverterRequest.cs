namespace ShoppingBasket.Application.Contracts.CurrencyConverter;

public record CurrencyConverterRequest(decimal Amount, string FromCurrency, string ToCurrency, int Precision=2);