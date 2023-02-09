namespace ShoppingBasket.Api.MappingProfiles;

public class BasketProfile:Profile
{
    public BasketProfile()
    {
        CreateMap<BasketItemDto, BasketItemModel>()
            .ForMember(dest => dest.TotalPrice,
                act => act.MapFrom(
                    src => src.Price * src.Quantity));
    }
}