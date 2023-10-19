using ShoppingBasket.Application.Contracts.Coupon;
using ShoppingBasket.Domain.Basket;

namespace ShoppingBasket.Infrastructure.Coupon;

public class Coupon:ICoupon
{
    public async Task<decimal> GetPrice(List<BasketItem> basketItems, int couponId)
    {
      //Get what coupon
      // if(quanity > 2)
      //(quantity%2) 
    }
}