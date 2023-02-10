namespace ShoppingBasket.Application.UnitTests.Features.Item.Queries.GetItems;

public class GetItemsQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IItemRepository> _mockItemRepository;
    private readonly Mock<ICurrencyConverter> _mockCurrencyConverter;

    public GetItemsQueryHandlerTests()
    {
        var mapperConfiguration = new MapperConfiguration(c =>
            c.AddProfile<ItemProfile>());
        _mapper = mapperConfiguration.CreateMapper();

        _mockItemRepository = new Mock<IItemRepository>();
        _mockCurrencyConverter = new Mock<ICurrencyConverter>();
    }

    private GetItemsQueryHandler GetSut() => new(_mapper, _mockItemRepository.Object, _mockCurrencyConverter.Object);

    [Fact]
    public void Handler_WhenCalledWithFaultyCurrencyCode_ThrowsBadRequestException()
    {
        var sut = GetSut();

        Assert.ThrowsAsync<BadRequestException>(() => sut.Handle(new GetItemsQuery("fake"), default));
    }


    [Fact]
    public void Handler_WhenNullItemsAreFound_ThrowsNotFoundException()
    {
        _mockItemRepository.Setup(m =>
            m.GetItems()).ReturnsAsync((List<Domain.Item.Item>) null);

        var sut = GetSut();

        Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(new GetItemsQuery("USD"), default));
    }

    [Fact]
    public void Handler_WhenNoItemsAreFound_ThrowsNotFoundException()
    {
        _mockItemRepository.Setup(m =>
            m.GetItems()).ReturnsAsync(new List<Domain.Item.Item>());

        var sut = GetSut();

        Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(new GetItemsQuery("USD"), default));
    }

    [Fact]
    public async Task Handler_WhenCalledWithValidUSDRequest_ReturnsExpectedType()
    {
        _mockItemRepository.Setup(m => m.GetItems()).ReturnsAsync(MockData.GetItems);

        var sut = GetSut();

        var result = await sut.Handle(new GetItemsQuery("USD"), default);

        AssertValidRequestResult(result, MockData.GetItems()[0].Price, MockData.GetItems()[1].Price,
            MockData.GetItems()[2].Price);
    }

    [Theory]
    [InlineData("USD", "GBP", 1)]
    [InlineData("USD", "EUR", 2)]
    public async Task Handler_WhenCalledWithValidRequest_ReturnsExpectedType(string fromCurrencyCode,
        string toCurrencyCode, decimal convertedPrice)
    {
        _mockItemRepository.Setup(m => m.GetItems()).ReturnsAsync(MockData.GetItems);
        SetupMockCurrencyConverter(fromCurrencyCode, toCurrencyCode, convertedPrice);
        var sut = GetSut();

        var result = await sut.Handle(new GetItemsQuery(toCurrencyCode), default);

        AssertValidRequestResult(result, convertedPrice, convertedPrice, convertedPrice);
    }

    private void SetupMockCurrencyConverter(string fromCurrencyCode, string toCurrencyCode, decimal convertedPrice)
    {
        _mockCurrencyConverter.Setup(c =>
            c.Convert(It.IsAny<CurrencyConverterRequest>())).ReturnsAsync((CurrencyConverterRequest t) =>
        {
            if (
                t.FromCurrency == fromCurrencyCode
                && t.ToCurrency == toCurrencyCode)
                return convertedPrice;

            return 0m;
        });
    }

    private void AssertValidRequestResult(List<ItemDto> result, decimal priceOne, decimal priceTwo, decimal priceThree)
    {
        result.ShouldBeOfType(typeof(List<ItemDto>));
        result[0].Price.ShouldBe(priceOne);
        result[1].Price.ShouldBe(priceTwo);
        result[2].Price.ShouldBe(priceThree);
    }
}