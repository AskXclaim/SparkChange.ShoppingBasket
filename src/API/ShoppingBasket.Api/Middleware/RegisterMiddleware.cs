namespace ShoppingBasket.Api.Middleware;

public static class RegisterMiddleware
{
    public static IApplicationBuilder UseException(this IApplicationBuilder builder) =>
        builder.UseMiddleware<ExceptionMiddleware>();
}