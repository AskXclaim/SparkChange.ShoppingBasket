using ShoppingBasket.Domain.Coupons;

namespace ShoppingBasket.Persistence.Configurations.Coupons;

public class CouponConfiguration:IEntityTypeConfiguration<Coupon>
{
    public void Configure(EntityTypeBuilder<Coupon> builder)
    {
        builder.HasData(
            new Coupon()
            {
                Id = 1, Description = "Two for One"
            });
    }
}