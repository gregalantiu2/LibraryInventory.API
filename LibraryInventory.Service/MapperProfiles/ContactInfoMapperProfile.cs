using AutoMapper;
using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Entities.Shared;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.SharedModels;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace LibraryInventory.Service.MapperProfiles
{
    public class ContactInfoMapperProfile : Profile
    {
        public ContactInfoMapperProfile()
        {
            CreateMap<ContactInfoEntity, ContactInfo>().ReverseMap();
        }
    }
}
