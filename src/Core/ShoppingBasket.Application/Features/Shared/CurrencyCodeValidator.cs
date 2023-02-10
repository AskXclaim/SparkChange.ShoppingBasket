namespace ShoppingBasket.Application.Features.Shared;

public class CurrencyCodeValidator:AbstractValidator<string>
{
    public CurrencyCodeValidator()
    {
     
        RuleFor(i => i)
            .NotEmpty()
            .WithMessage("CurrencyCode must be present");
        RuleFor(i => i)
            .MaximumLength(3)
            .WithMessage("CurrencyCode must have a max length of {ComparisonValue}");
        RuleFor(i => i)
            .MinimumLength(3)
            .WithMessage("CurrencyCode must have a min length of {ComparisonValue}");
        
    }
}