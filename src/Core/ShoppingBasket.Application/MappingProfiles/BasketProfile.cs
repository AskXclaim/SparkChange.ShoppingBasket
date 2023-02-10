namespace ShoppingBasket.Application.MappingProfiles;

public class BasketProfile : Profile
{
    public BasketProfile()
    {
        CreateMap<BasketItem, BasketItemDto>()
            .ForMember(dest => dest.BasketKey, act 
                => act.MapFrom(src => src.ShoppingBasketKey));
    }
}