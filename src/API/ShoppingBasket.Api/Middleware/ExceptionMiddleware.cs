namespace ShoppingBasket.Api.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionMiddleware(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception e)
        {
            await HandleExceptionAsync(context, e);
        }
    }


    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        var statusCode = (int) HttpStatusCode.InternalServerError;
        ProblemDetails problem;

        switch (exception)
        {
            case NotFoundException notFoundException:
                statusCode = (int) HttpStatusCode.NotFound;
                problem = GetProblemDetails("A Not found exception occurred", notFoundException, statusCode,
                    nameof(NotFoundException));
                break;
            default:
                problem = GetProblemDetails("A server exception occurred", exception, statusCode,
                    nameof(HttpStatusCode.InternalServerError));
                break;
        }

        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(problem);
    }

    private ProblemDetails GetProblemDetails(string title, Exception exception, int statusCode, string typeOfException)
    {
        return new ProblemDetails()
        {
            Title = title,
            Status = statusCode,
            Detail = GetInnerExceptionMessage(exception),
            Type = typeOfException
        };
    }

    private string GetInnerExceptionMessage(Exception exception) =>
        exception.InnerException != null ? exception.InnerException.Message : exception.Message;
}