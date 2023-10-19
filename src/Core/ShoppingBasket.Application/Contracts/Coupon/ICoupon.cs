namespace ShoppingBasket.Application.Contracts.Coupon;

public interface ICoupon
{
    Task<decimal> GetPrice(List<BasketItem> basketItems, int couponId);
}