namespace ShoppingBasket.Application.CustomException;

public class BadRequestException : Exception
{
    public string Errors { get; set; } = string.Empty;

    public BadRequestException(string message) : base(message)
    {
    }

    public BadRequestException(string message, ValidationResult validationResult)
        : base(message)
    {
        var stringBuilder = new StringBuilder();
        foreach (var error in validationResult.Errors)
            stringBuilder.AppendLine(error.ErrorMessage);

        Errors = stringBuilder.ToString().Trim();
    }
}