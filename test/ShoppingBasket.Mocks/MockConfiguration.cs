namespace ShoppingBasket.MockData;

public static class MockConfiguration
{
    public static IMapper GetMapper<T>() where T : Profile, new()
    {
        var mapperConfiguration = new MapperConfiguration(
            c => c.AddProfile<T>());

        return mapperConfiguration.CreateMapper();
    }

    public static IConfiguration GetMockConfiguration()
    {
        var mockConfigurationSection = new Mock<IConfigurationSection>();
        mockConfigurationSection
            .Setup(x => x.Value)
            .Returns("USD");
        var mockConfiguration = new Mock<IConfiguration>();
        mockConfiguration.Setup(c => c.GetSection("DefaultCurrencyCode"))
            .Returns(mockConfigurationSection.Object);

        return mockConfiguration.Object;
    }
}