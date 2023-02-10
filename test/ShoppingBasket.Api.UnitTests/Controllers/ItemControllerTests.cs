namespace ShoppingBasket.Api.UnitTests.Controllers;

public class ItemControllerTests
{
    private readonly Mock<IMediator> _mockMediator;
    private readonly Mock<IConfiguration> _mockConfiguration;

    public ItemControllerTests()
    {
        _mockMediator = new Mock<IMediator>();
        _mockConfiguration = new Mock<IConfiguration>();
        var mockConfigurationSection = new Mock<IConfigurationSection>();
        mockConfigurationSection
            .Setup(x => x.Value)
            .Returns("USD");
        _mockConfiguration.Setup(c => c.GetSection("DefaultCurrencyCode"))
            .Returns(mockConfigurationSection.Object);
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData(" ")]
    [InlineData("GBP")]
    public async Task GetItem_WhenCalled_ReturnsExpectedType(string currencyCode)
    {
        _mockMediator.Setup(m => m.Send(It.IsAny<GetItemWithDetailsQuery>(),
            default)).ReturnsAsync(MockData.MockData.GetItemDetailsDto);

        var sut = new ItemController(_mockMediator.Object, _mockConfiguration.Object);

        var result =await sut.GetItem(1, currencyCode);

        var okResult = result.Result as OkObjectResult;
        okResult?.StatusCode.ShouldBe(200);
        okResult?.Value.ShouldBeOfType<ItemDetailsDto>();
    }
    
    [Theory]
    [InlineData(null)]
    [InlineData(" ")]
    [InlineData("GBP")]
    public async Task GetAllItems_WhenCalled_ReturnsExpectedType(string currencyCode)
    {
        _mockMediator.Setup(m => m.Send(It.IsAny<GetItemsQuery>(),
            default)).ReturnsAsync(MockData.MockData.GeItemDtos());

        var sut = new ItemController(_mockMediator.Object, _mockConfiguration.Object);

        var result =await sut.GetAllItems( currencyCode);

        var okResult = result.Result as OkObjectResult;
        okResult?.StatusCode.ShouldBe(200);
        okResult?.Value.ShouldBeOfType<List<ItemDto>>();
    }
}