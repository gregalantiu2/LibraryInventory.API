using AutoMapper;
using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Entities.Item;
using LibraryInventory.Model.ItemModels;
using LibraryInventory.Model.RequestModels.Item;

namespace LibraryInventory.Service.MapperProfiles
{
    public class ItemMapperProfile : Profile
    {
        public ItemMapperProfile()
        {
            CreateMap<ItemPolicyRequest, ItemFineOccurenceType>()
                .ForMember(dest => dest.ItemFineOccurenceTypeId, opt => opt.MapFrom(src => src.ItemFineOccurenceTypeId));

            CreateMap<ItemPolicyRequest, ItemPolicy>()
                .ForCtorParam("itemPolicyName", opt => opt.MapFrom(src => src.ItemPolicyName))
                .ForCtorParam("allowedToCheckout", opt => opt.MapFrom(src => src.AllowedToCheckout))
                .ForCtorParam("maxRenewalsAllowed", opt => opt.MapFrom(src => src.MaxRenewalsAllowed))
                .ForCtorParam("checkoutDays", opt => opt.MapFrom(src => src.CheckoutDays))
                .ForCtorParam("fineAmount", opt => opt.MapFrom(src => src.FineAmount))
                .ForCtorParam("itemFineOccurenceType", opt => opt.MapFrom(src => src))
                .ForCtorParam("itemPolicyId", opt => opt.MapFrom(src => src.ItemPolicyId));

            CreateMap<ItemRequest, Item>()
                .ForCtorParam("itemTitle", opt => opt.MapFrom(src => src.ItemTitle))
                .ForCtorParam("itemDescription", opt => opt.MapFrom(src => src.ItemDescription))
                .ForCtorParam("itemType", opt => opt.MapFrom(src => src))
                .ForCtorParam("itemPolicy", opt => opt.MapFrom(src => src))
                .ForCtorParam("itemLocation", opt => opt.MapFrom(src => src.ItemLocation))
                .ForCtorParam("itemId", opt => opt.MapFrom(src => src.ItemId));

            CreateMap<ItemRequest, ItemType>()
                .ForMember(dest => dest.ItemTypeId, opt => opt.MapFrom(src => src.ItemTypeId));

            CreateMap<ItemType, ItemTypeEntity>();

            CreateMap<ItemPolicy, ItemPolicyEntity>()
                .ForMember(dest => dest.ItemFineOccurenceTypeId, opt => opt.MapFrom(src => src.ItemFineOccurenceType.ItemFineOccurenceTypeId));

            CreateMap<ItemPolicyEntity, ItemPolicy>();

            CreateMap<ItemFineOccurenceType, ItemFineOccurenceTypeEntity>().ReverseMap();

            CreateMap<ItemBorrowStatus, ItemBorrowStatusEntity>().ReverseMap();

            CreateMap<Item, ItemEntity>().ReverseMap();
        }
    }
}
