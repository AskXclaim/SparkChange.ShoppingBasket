namespace ShoppingBasket.Application.CustomException;

public class BadRequestException : Exception
{
    public BadRequestException(string message):base(message)
    {
    }
    public BadRequestException(string message, ValidationResult validationResult)
        : base(message, new Exception(validationResult.Errors.ToString()))
    {
    }
}