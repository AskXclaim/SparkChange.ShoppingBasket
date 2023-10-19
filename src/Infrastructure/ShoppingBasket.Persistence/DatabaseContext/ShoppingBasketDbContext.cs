using ShoppingBasket.Domain.Coupons;

namespace ShoppingBasket.Persistence.DatabaseContext;

public class ShoppingBasketDbContext:Microsoft.EntityFrameworkCore.DbContext
{
    public ShoppingBasketDbContext(DbContextOptions<ShoppingBasketDbContext> options): base(options)
    {
        
    }

    public DbSet<Item> Items { get; set; }
    public DbSet<BasketItem> BasketItems { get; set; }
    public DbSet<Coupon> Coupons { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShoppingBasketDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}