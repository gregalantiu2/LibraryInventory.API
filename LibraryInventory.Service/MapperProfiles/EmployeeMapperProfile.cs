using AutoMapper;
using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.RequestModels;
using LibraryInventory.Model.SharedModels;

namespace LibraryInventory.Service.MapperProfiles
{
    public class EmployeeMapperProfile : Profile
    {
        public EmployeeMapperProfile()
        {
            CreateMap<EmployeeRequest, ContactInfo>()
                .ForCtorParam("phoneNumber", opt => opt.MapFrom(src => src.PhoneNumber))
                .ForCtorParam("email", opt => opt.MapFrom(src => src.Email))
                .ForCtorParam("street", opt => opt.MapFrom(src => src.Street))
                .ForCtorParam("city", opt => opt.MapFrom(src => src.City))
                .ForCtorParam("state", opt => opt.MapFrom(src => src.State))
                .ForCtorParam("zipCode", opt => opt.MapFrom(src => src.ZipCode))
                .ForCtorParam("country", opt => opt.MapFrom(src => src.Country));

            CreateMap<EmployeeRequest, EmployeeType>()
                .ForCtorParam("employeeTypeId", opt => opt.MapFrom(src => src.EmployeeTypeId));

            CreateMap<EmployeeRequest, Employee>()
                .ForCtorParam("firstName", opt => opt.MapFrom(src => src.FirstName))
                .ForCtorParam("lastName", opt => opt.MapFrom(src => src.LastName))
                .ForCtorParam("contactinfo", opt => opt.MapFrom(src => src))
                .ForCtorParam("employeeId", opt => opt.MapFrom(src => src.EmployeeId))
                .ForCtorParam("employeeType", opt => opt.MapFrom(src => src));

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
                .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active))
                .ForMember(dest => dest.EmployeeTypeId, opt => opt.MapFrom(src => src.EmployeeType.EmployeeTypeId));

            CreateMap<EmployeeType, EmployeeTypeEntity>()
                .ForMember(dest => dest.EmployeeTypeId, opt => opt.MapFrom(src => src.EmployeeTypeId));

            CreateMap<EmployeeTypeEntity, EmployeeType>()
                .ForCtorParam("employeeTypeId", opt => opt.MapFrom(src => src.EmployeeTypeId))
                .ForCtorParam("employeeTypeName", opt => opt.MapFrom(src => src.EmployeeTypeName));

            CreateMap<EmployeeEntity, EmployeeEntity>()
                .ForMember(dest => dest.EmployeeKeyId, opt => opt.Ignore())
                .ForMember(dest => dest.EmployeeType, opt => opt.Ignore())
                .ForMember(dest => dest.ContactInfo, opt => opt.Ignore());
        }
    }
}
