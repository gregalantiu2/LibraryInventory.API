using AutoMapper;
using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Entities.Shared;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.SharedModels;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace LibraryInventory.Service.MapperProfiles
{
    public class EmployeeMapperProfile : Profile
    {
        public EmployeeMapperProfile()
        {
            CreateMap<EmployeeEntity, Employee>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src =>
                    string.IsNullOrEmpty(src.EmployeeId) ? src.EmployeeKeyId.ToString() : src.EmployeeId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));

            CreateMap<Employee, EmployeeEntity>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));

            CreateMap<EmployeeTypeEntity, EmployeeType>().ReverseMap();
        }
    }
}
