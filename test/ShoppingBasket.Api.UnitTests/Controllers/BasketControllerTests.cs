namespace ShoppingBasket.Api.UnitTests.Controllers;

public class BasketControllerTests
{
    private readonly Mock<IMediator> _mockMediator;
    private readonly IMapper _mapper;
    private readonly IConfiguration _mockConfiguration;

    public BasketControllerTests()
    {
        _mockMediator = new Mock<IMediator>();
        _mapper = MockData.MockConfiguration.GetMapper<BasketProfile>();
        _mockConfiguration = MockData.MockConfiguration.GetMockConfiguration();
    }

    [Theory]
    [InlineData(null)]
    [InlineData(" ")]
    [InlineData("GBP")]
    public async Task GetItemFromBasket_When_A_ValidCallIsMade_ReturnsExpectedType(string currencyCode)
    {
        _mockMediator.Setup(m => m.Send(It.IsAny<GetItemFromBasketQuery>(),
            default)).ReturnsAsync(MockData.MockData.GetBasketItemDto);
        var sut = new BasketController(_mockMediator.Object, _mapper, _mockConfiguration);
        var result = await sut.GetItemFromBasket(1, currencyCode, "basketKey");
        var okResult = result.Result as OkObjectResult;
        okResult?.StatusCode.ShouldBe(200);
        okResult?.Value.ShouldBeOfType<BasketItemModel>();
    }

    [Fact]
    public async Task GetItemFromBasket_When_An_InvalidCallIsMade_ThrowsBadRequestException()
    {
        _mockMediator.Setup(m => m.Send(It.IsAny<GetItemFromBasketQuery>(),
            default)).ThrowsAsync(new BadRequestException("Test message"));
        var sut = new BasketController(_mockMediator.Object, _mapper, _mockConfiguration);
        await Assert.ThrowsAsync<BadRequestException>(() => sut.GetItemFromBasket(1, "USDB", "basketKey"));
    }

    [Fact]
    public async Task GetItemFromBasket_When_An_InvalidCallIsMade_ThrowsNotFoundException()
    {
        _mockMediator.Setup(m => m.Send(It.IsAny<GetItemFromBasketQuery>(),
            default)).ThrowsAsync(new NotFoundException("Test message"));
        var sut = new BasketController(_mockMediator.Object, _mapper, _mockConfiguration);
        await Assert.ThrowsAsync<NotFoundException>(() => sut.GetItemFromBasket(1, "USDB", "basketKey"));
    }

    [Theory]
    [InlineData(null)]
    [InlineData(" ")]
    [InlineData("GBP")]
    public async Task GetAllItemsInBasket_When_A_ValidCallIsMade_ReturnsExpectedType(string currencyCode)
    {
        _mockMediator.Setup(m => m.Send(It.IsAny<GetAllItemsFromBasketQuery>(),
            default)).ReturnsAsync(MockData.MockData.GetBasketItemsDto);
        var sut = new BasketController(_mockMediator.Object, _mapper, _mockConfiguration);
        var result = await sut.GetAllItemsInBasket(currencyCode, "basketKey");
        var okResult = result.Result as OkObjectResult;
        okResult?.StatusCode.ShouldBe(200);
        okResult?.Value.ShouldBeOfType<BasketItemsModel>();
        result.Value?.TotalPriceOfItems.ShouldBe(MockData.MockData.GetBasketItemsDto().Sum(i => i.Quantity * i.Price));
    }

    [Fact]
    public async Task AddItemToBasket_When_A_ValidCallIsMade_ReturnsCreatedAtAction()
    {
        _mockMediator.Setup(m => m.Send(It.IsAny<UpsertBasketCommand>(),
            default));
        var sut = new BasketController(_mockMediator.Object, _mapper, _mockConfiguration);
        var result = await sut.AddItemToBasket("basketkey", 1, 2);
        Assert.IsType<CreatedAtActionResult>(result);
    }
    
    [Fact]
    public async Task UpdateItemInBasket_When_A_ValidCallIsMade_ReturnsNoContent()
    {
        _mockMediator.Setup(m => m.Send(It.IsAny<UpsertBasketCommand>(),
            default));
        var sut = new BasketController(_mockMediator.Object, _mapper, _mockConfiguration);
        var result = await sut.UpdateItemInBasket("basketkey", 1, 2);
        Assert.IsType<NoContentResult>(result);
    }
    [Fact]
    public async Task RemoveItemFromBasket_When_A_ValidCallIsMade_ReturnsNoContent()
    {
        _mockMediator.Setup(m => m.Send(It.IsAny<RemoveItemFromBasketCommand>(),
            default));
        var sut = new BasketController(_mockMediator.Object, _mapper, _mockConfiguration);
        var result = await sut.RemoveItemFromBasket("basketkey", 1 );
        Assert.IsType<NoContentResult>(result);
    }
    
    [Fact]
    public async Task RemoveAllItemsFromBasket_When_A_ValidCallIsMade_ReturnsNoContent()
    {
        _mockMediator.Setup(m => m.Send(It.IsAny<RemoveAllItemsFromBasketCommand>(),
            default));
        var sut = new BasketController(_mockMediator.Object, _mapper, _mockConfiguration);
        var result = await sut.RemoveAllItemsFromBasket("basketkey");
        Assert.IsType<NoContentResult>(result);
    }
}