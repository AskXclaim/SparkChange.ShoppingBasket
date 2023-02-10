namespace ShoppingBasket.Application.MappingProfiles;

public class ItemProfile:Profile
{
    public ItemProfile()
    {
        CreateMap<Item,ItemDetailsDto>();
        CreateMap<Item, ItemDto>();
    }
}