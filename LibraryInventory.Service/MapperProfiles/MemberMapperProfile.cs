using AutoMapper;
using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Entities.Shared;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.SharedModels;

namespace LibraryInventory.Service.MapperProfiles
{
    public class MemberMapperProfile : Profile
    {
        public MemberMapperProfile()
        {
            CreateMap<MemberEntity, Member>().ReverseMap();
        }
    }
}
