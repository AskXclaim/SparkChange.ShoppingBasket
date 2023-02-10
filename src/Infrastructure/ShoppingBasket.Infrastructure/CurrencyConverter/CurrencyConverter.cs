using ShoppingBasket.Application.CustomException;

namespace ShoppingBasket.Infrastructure.CurrencyConverter;

public class CurrencyConverter : ICurrencyConverter
{
    private readonly CurrencyConverterSettings _currencyConverterSettings;
    private readonly IHttpClientFactory _clientFactory;

    public CurrencyConverter(IOptions<CurrencyConverterSettings> currencyConverterSettings,
        IHttpClientFactory clientFactory)
    {
        _currencyConverterSettings = currencyConverterSettings.Value;
        _clientFactory = clientFactory;
    }

    public async Task<decimal> Convert(CurrencyConverterRequest request)
    {
        var from = GetFrom(request);
        using var client = GetHttpClient();
        var requestMessage = GetHttpRequestMessage(request, from);
        var responseMessage = await client.SendAsync(requestMessage);

        if (responseMessage.IsSuccessStatusCode)
        {
            var content = await responseMessage.Content.ReadAsStringAsync();
            if (content.Contains("error", StringComparison.OrdinalIgnoreCase))
            {
                var errorResult = JsonSerializer.Deserialize<CurrencyDataErrorResult>(content, GetJsonSerializerOptions());
                throw new BadRequestException(errorResult?.Error?.Detail);
            }

            var successResult = JsonSerializer.Deserialize<CurrencyDataSuccessResult>(content, GetJsonSerializerOptions());
            if (successResult != null) return (decimal) successResult.Result;
        }
        else
        {
            throw new Exception($"Unable to convert currency: '{responseMessage.ReasonPhrase}'");
        }

        throw new Exception("Unable to convert currency");
    }


    private string GetFrom(CurrencyConverterRequest request)
    {
        var from = _currencyConverterSettings.From;
        if (!string.IsNullOrWhiteSpace(request.FromCurrency))
            from = request.FromCurrency;

        return from;
    }

    private HttpClient GetHttpClient()
    {
        var client = _clientFactory.CreateClient();
        client.DefaultRequestHeaders.Add($"{nameof(_currencyConverterSettings.ApiKey).ToLower()}",
            _currencyConverterSettings.ApiKey);

        return client;
    }

    private HttpRequestMessage GetHttpRequestMessage(CurrencyConverterRequest request, string from)
    {
        var builder = new UriBuilder(_currencyConverterSettings.Url)
        {
            Query = $"to={request.ToCurrency}&from={from}&amount={request.Amount}"
        };
        var url = builder.ToString();

        return new HttpRequestMessage(HttpMethod.Get, url);
    }

    private JsonSerializerOptions GetJsonSerializerOptions() => new()
    {
        PropertyNameCaseInsensitive = true
    };
}