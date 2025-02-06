using AutoMapper;
using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Entities.Shared;
using LibraryInventory.Model.ItemModels;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.RequestModels.Person;
using LibraryInventory.Model.SharedModels;
using System.Text.Json;

namespace LibraryInventory.Service.MapperProfiles
{
    public class MemberMapperProfile : Profile
    {
        public MemberMapperProfile()
        {
            CreateMap<MemberRequest, ContactInfo>()
                .ForCtorParam("phoneNumber", opt => opt.MapFrom(src => src.PhoneNumber))
                .ForCtorParam("email", opt => opt.MapFrom(src => src.Email))
                .ForCtorParam("street", opt => opt.MapFrom(src => src.Street))
                .ForCtorParam("city", opt => opt.MapFrom(src => src.City))
                .ForCtorParam("state", opt => opt.MapFrom(src => src.State))
                .ForCtorParam("zipCode", opt => opt.MapFrom(src => src.ZipCode))
                .ForCtorParam("country", opt => opt.MapFrom(src => src.Country));

            CreateMap<MemberRequest, Member>()
                .ForCtorParam("firstName", opt => opt.MapFrom(src => src.FirstName))
                .ForCtorParam("lastName", opt => opt.MapFrom(src => src.LastName))
                .ForCtorParam("contactinfo", opt => opt.MapFrom(src => src))
                .ForCtorParam("memberId", opt => opt.MapFrom(src => src.MemberId));

            //CreateMap<MemberEntity, Member>()
            //    .ForCtorParam("memberId", opt => opt.MapFrom(src =>
            //                       string.IsNullOrEmpty(src.MemberId) ? src.MemberKeyId.ToString() : src.MemberId))
            //    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            //    .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
            //    .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            //    .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));

            CreateMap<MemberEntity, Member>()
                .ForCtorParam("firstName", opt => opt.MapFrom(src => src.FirstName))
                .ForCtorParam("lastName", opt => opt.MapFrom(src => src.LastName))
                .ForCtorParam("contactinfo", opt => opt.MapFrom(src => src.ContactInfo))
                .ForCtorParam("fineAmountOwed", opt => opt.MapFrom(src => src.FineAmountOwed))
                .ForCtorParam("memberId", opt => opt.MapFrom(src =>
                                  string.IsNullOrEmpty(src.MemberId) ? src.MemberKeyId.ToString() : src.MemberId))
                .ForCtorParam("memberKeyId", opt => opt.MapFrom(src => src.MemberKeyId));

            CreateMap<Member, MemberEntity>()
                .ForMember(dest => dest.MemberId, opt => opt.MapFrom(src => src.MemberId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));
        }
    }
}
