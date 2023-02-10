namespace ShoppingBasket.Application.UnitTests.Features.Item.Queries.GetItemDetails;

public class GetItemWithDetailsQueryHandlerTests
{
    private readonly IMapper _mapper;
    private readonly Mock<IItemRepository> _mockItemRepository;
    private readonly Mock<ICurrencyConverter> _mockCurrencyConverter;

    public GetItemWithDetailsQueryHandlerTests()
    {
        var mapperConfiguration = new MapperConfiguration(c =>
            c.AddProfile<ItemProfile>());
        _mapper = mapperConfiguration.CreateMapper();

        _mockItemRepository = new Mock<IItemRepository>();
        _mockCurrencyConverter = new Mock<ICurrencyConverter>();
    }

    [Fact]
    public void Handler_WhenCalledWithFaultyCurrencyCode_ThrowsBadRequestException()
    {
        var sut = new GetItemWithDetailsQueryHandler(_mapper, _mockItemRepository.Object,
            _mockCurrencyConverter.Object);

        Assert.ThrowsAsync<BadRequestException>(() => sut.Handle(new GetItemWithDetailsQuery(0, "fake"), default));
    }

    [Fact]
    public void Handler_WhenCalledWithFaultyId_ThrowsNotFoundException()
    {
        _mockItemRepository.Setup(m =>
            m.GetItemWithDetails(It.IsAny<int>())).ReturnsAsync((Domain.Item.Item?) null);

        var sut = new GetItemWithDetailsQueryHandler(_mapper, _mockItemRepository.Object,
            _mockCurrencyConverter.Object);

        Assert.ThrowsAsync<NotFoundException>(() => sut.Handle(new GetItemWithDetailsQuery(0, "USD"), default));
    }

    [Theory]
    [InlineData("USD")]
    [InlineData("GBP")]
    [InlineData("EUR")]
    public async Task Handler_WhenCalledWithValidIdAndCurrencyCodes_ReturnsExpectedType(string currencyCode)
    {
        _mockItemRepository.Setup(m =>
            m.GetItemWithDetails(It.IsAny<int>())).ReturnsAsync(MockData.GetItem);

        var sut = new GetItemWithDetailsQueryHandler(_mapper, _mockItemRepository.Object,
            _mockCurrencyConverter.Object);

        var result = await sut.Handle(new GetItemWithDetailsQuery(1, currencyCode), default);
        result.ShouldBeOfType(typeof(ItemDetailsDto));
    }
}