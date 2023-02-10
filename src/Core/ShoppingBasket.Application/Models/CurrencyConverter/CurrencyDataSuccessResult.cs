namespace ShoppingBasket.Application.Models.CurrencyConverter;

public class CurrencyDataSuccessResult
{
    public double Result { get; set; }
    [JsonPropertyName("success")]
    public bool IsSuccess { get; set; }
}