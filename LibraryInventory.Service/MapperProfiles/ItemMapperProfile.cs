using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LibraryInventory.Data.Entities;
using LibraryInventory.Data.Entities.Item;
using LibraryInventory.Model.ItemModels;

namespace LibraryInventory.Service.MapperProfiles
{
    public class ItemMapperProfile : Profile
    {
        public ItemMapperProfile()
        {
            CreateMap<ItemDetail, ItemDetailEntity>();
            CreateMap<ItemType, ItemTypeEntity>();
            CreateMap<ItemPolicy, ItemPolicyEntity>();
            CreateMap<ItemFineOccurenceType, ItemFineOccurenceTypeEntity>();
            CreateMap<ItemBorrowStatus, ItemBorrowStatusEntity>();
            CreateMap<Item, ItemEntity>();
        }
    }
}
