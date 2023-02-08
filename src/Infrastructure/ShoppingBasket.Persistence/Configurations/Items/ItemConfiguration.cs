namespace ShoppingBasket.Persistence.Configurations.Items;

public class ItemConfiguration : IEntityTypeConfiguration<Item>
{
    public void Configure(EntityTypeBuilder<Item> builder)
    {
        var items = new List<Item>()
        {
            new()
            {
                Id = 1, Name = "Soup",
                Price = 0.65M,
                Description = "Delicious Soup"
            },
            new()
            {
                Id = 2, Name = "Bread",
                Price = 0.80M,
                Description = "Lovely Bread"
            },
            new()
            {
                Id = 3, Name = "Milk",
                Price = 1.15M,
                Description = "Deluxe Milk"
            },
            new()
            {
                Id = 4, Name = "Apples",
                Price = 1.00M,
                Description = "Good ol Apples"
            }
        };

        builder.HasData(items);
    }
}