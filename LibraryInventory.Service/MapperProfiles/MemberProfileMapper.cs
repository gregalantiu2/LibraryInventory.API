using AutoMapper;
using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Entities.Shared;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.SharedModels;

namespace LibraryInventory.Service.MapperProfiles
{
    public class MemberProfileMapper : Profile
    {
        public MemberProfileMapper()
        {
            CreateMap<MemberEntity, Member>().ReverseMap();
            CreateMap<ContactInfoEntity, ContactInfo>().ReverseMap();
        }
    }
}
