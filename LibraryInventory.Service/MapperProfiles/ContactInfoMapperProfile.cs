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
            //CreateMap<ContactInfoEntity, ContactInfo>()
            //    .ForCtorParam("contactInfoId", opt => opt.MapFrom(src => src.ContactInfoId))
            //    .ReverseMap();

            CreateMap<ContactInfoEntity, ContactInfo>()
                .ForCtorParam("phoneNumber", opt => opt.MapFrom(src => src.PhoneNumber))
                .ForCtorParam("email", opt => opt.MapFrom(src => src.Email))
                .ForCtorParam("street", opt => opt.MapFrom(src => src.Street))
                .ForCtorParam("city", opt => opt.MapFrom(src => src.City))
                .ForCtorParam("state", opt => opt.MapFrom(src => src.State))
                .ForCtorParam("zipCode", opt => opt.MapFrom(src => src.ZipCode))
                .ForCtorParam("country", opt => opt.MapFrom(src => src.Country))
                .ForCtorParam("contactInfoId", opt => opt.MapFrom(src => src.ContactInfoId));

            CreateMap<ContactInfo, ContactInfoEntity>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Street))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.ZipCode))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.ContactInfoId, opt => opt.MapFrom(src => src.ContactInfoId));
        }
    }
}
