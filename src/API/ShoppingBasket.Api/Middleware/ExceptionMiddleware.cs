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
                problem = GetProblemDetails("Not found exception", notFoundException, statusCode,
                    nameof(NotFoundException));
                break;
            case BadRequestException badRequestException:
                statusCode = (int) HttpStatusCode.BadRequest;
                problem = GetProblemDetails("Bad request exception", badRequestException, statusCode,
                    nameof(BadRequestException));
                break;
            default:
                problem = GetProblemDetails("Server exception", exception, statusCode,
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
            Detail = GetExceptionDetails(exception),
            Type = typeOfException
        };
    }

    private string GetExceptionDetails(Exception exception) =>
        exception.InnerException != null ? exception.InnerException.Message : exception.Message;
}