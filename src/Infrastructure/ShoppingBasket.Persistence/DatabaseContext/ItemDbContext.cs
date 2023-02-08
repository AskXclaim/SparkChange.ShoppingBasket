namespace ShoppingBasket.Persistence.DatabaseContext;

public class ItemDbContext:Microsoft.EntityFrameworkCore.DbContext
{
    public ItemDbContext(DbContextOptions<ItemDbContext> options): base(options)
    {
        
    }

    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ItemDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}