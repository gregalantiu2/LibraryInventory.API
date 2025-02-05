using AutoMapper;
using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Entities.Item;
using LibraryInventory.Model.ItemModels;
using LibraryInventory.Model.RequestModels;

namespace LibraryInventory.Service.MapperProfiles
{
    public class ItemMapperProfile : Profile
    {
        public ItemMapperProfile()
        {
            CreateMap<ItemRequest, ItemType>()
                .ForCtorParam("itemTypeId", opt => opt.MapFrom(src => src.ItemTypeId));

            CreateMap<ItemRequest, ItemPolicy>()
                .ForCtorParam("itemPolicyId", opt => opt.MapFrom(src => src.ItemPolicyId));

            CreateMap<ItemRequest, Item>()
                .ForCtorParam("itemTitle", opt => opt.MapFrom(src => src.ItemTitle))
                .ForCtorParam("itemDescription", opt => opt.MapFrom(src => src.ItemDescription))
                .ForCtorParam("itemType", opt => opt.MapFrom(src => src))
                .ForCtorParam("itemPolicy", opt => opt.MapFrom(src => src))
                .ForCtorParam("itemLocation", opt => opt.MapFrom(src => src.ItemLocation))
                .ForCtorParam("itemId", opt => opt.MapFrom(src => src.ItemId));

            CreateMap<ItemType, ItemTypeEntity>();

            CreateMap<ItemPolicy, ItemPolicyEntity>();

            CreateMap<ItemFineOccurenceType, ItemFineOccurenceTypeEntity>();

            CreateMap<ItemBorrowStatus, ItemBorrowStatusEntity>();

            CreateMap<Item, ItemEntity>();
        }
    }
}
