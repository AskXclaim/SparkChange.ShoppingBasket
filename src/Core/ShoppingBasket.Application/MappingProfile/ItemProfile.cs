namespace ShoppingBasket.Application.MappingProfile;

public class ItemProfile:Profile
{
    public ItemProfile()
    {
        CreateMap<Item,ItemDetailsDto>();
        CreateMap<Item, ItemDto>();
    }
}