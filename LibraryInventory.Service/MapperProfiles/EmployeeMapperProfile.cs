using AutoMapper;
using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Model.PersonModels;

namespace LibraryInventory.Service.MapperProfiles
{
    public class EmployeeMapperProfile : Profile
    {
        public EmployeeMapperProfile()
        {
            CreateMap<EmployeeEntity, Employee>()
                .ForCtorParam("employeeId", opt => opt.MapFrom(src =>
                    string.IsNullOrEmpty(src.EmployeeId) ? src.EmployeeKeyId.ToString() : src.EmployeeId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));

            CreateMap<Employee, EmployeeEntity>()
                .ForMember(dest => dest.EmployeeId, opt => opt.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active));

            CreateMap<EmployeeTypeEntity, EmployeeType>()
                .ForCtorParam("employeeTypeId", opt => opt.MapFrom(src => src.EmployeeTypeId))
                .ReverseMap();
        }
    }
}
