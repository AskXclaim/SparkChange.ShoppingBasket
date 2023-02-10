namespace ShoppingBasket.Application.Models.CurrencyConverter;

public class CurrencyDataErrorResult
{
    public CurrencyDataError? Error { get; set; } = null;
    [JsonPropertyName("success")]
    public bool IsSuccess { get; set; }
}