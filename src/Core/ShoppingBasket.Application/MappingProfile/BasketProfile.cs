namespace ShoppingBasket.Application.MappingProfile;

public class BasketProfile : Profile
{
    public BasketProfile()
    {
        CreateMap<BasketItem, BasketItemDto>()
            .ForMember(dest => dest.BasketKey, act => act.MapFrom(src => src.ShoppingBasketKey))
            .ForMember(dest => dest.ItemId, act => act.MapFrom(src => src.Id));
    }
}