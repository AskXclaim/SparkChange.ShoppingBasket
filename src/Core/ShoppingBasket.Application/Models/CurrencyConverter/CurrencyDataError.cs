namespace ShoppingBasket.Application.Models.CurrencyConverter;

public class CurrencyDataError
{
    [JsonPropertyName("code")]
    public int StatusCode { get; set; }
    [JsonPropertyName("info")]
    public string Detail { get; set; } = string.Empty;
}