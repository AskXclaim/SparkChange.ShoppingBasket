namespace ShoppingBasket.Api.UnitTests.Middleware;

public class ExceptionMiddlewareTests
{
    private readonly DefaultHttpContext _context;

    public ExceptionMiddlewareTests()
    { 
        _context = new DefaultHttpContext
        {
            Response =
            {
                Body = new MemoryStream()
            }
        };
    }
     
    [Fact]
    public async Task Invoke_WhenNotFoundExceptionOccurs_ReturnCorrectException()
    {
        var middleware = new ExceptionMiddleware((innerHttpContext) =>
            throw new NotFoundException("Test", "Test"));

        await middleware.InvokeAsync(_context);

        var streamText = await GetResponseBodyAsText();

        streamText.ShouldBe("{\"type\":\"NotFoundException\"," +
                            "\"title\":\"Not found exception\",\"status\":404," +
                            "\"detail\":\"Test: Test not found\"}");
        _context.Response.StatusCode
            .ShouldBe((int)HttpStatusCode.NotFound);
    }
    
    [Fact]
    public async Task Invoke_WhenBadRequestExceptionOccurs_ReturnCorrectException()
    {
        var middleware = new ExceptionMiddleware((innerHttpContext) =>
            throw new BadRequestException("Test"));

        await middleware.InvokeAsync(_context);

        var streamText = await GetResponseBodyAsText();

        streamText.ShouldBe("{\"type\":\"BadRequestException\"," +
                            "\"title\":\"Bad request exception\",\"status\":400," +
                            "\"detail\":\"\"}");
        _context.Response.StatusCode
            .ShouldBe((int)HttpStatusCode.BadRequest);
    }
    [Fact]
    public async Task Invoke_WhenOtherExceptionOccurs_ReturnCorrectException()
    {
        var middleware = new ExceptionMiddleware((innerHttpContext) =>
            throw new Exception("Test"));

        await middleware.InvokeAsync(_context);

        var streamText = await GetResponseBodyAsText();

        streamText.ShouldBe("{\"type\":\"InternalServerError\"," +
                            "\"title\":\"Server exception\",\"status\":500," +
                            "\"detail\":\"Test\"}");
        _context.Response.StatusCode
            .ShouldBe((int)HttpStatusCode.InternalServerError);
    }
    private async Task<string> GetResponseBodyAsText()
    {
        _context.Response.Body.Seek(0, SeekOrigin.Begin);
        var reader = new StreamReader(_context.Response.Body);
        var streamText = await reader.ReadToEndAsync();
        return streamText;
    }
}