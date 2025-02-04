using AutoMapper;
using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Repositories.Interfaces;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.SharedModels;
using LibraryInventory.Service.Interfaces;

namespace LibraryInventory.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<Employee> AddEmployeeAsync(Employee employee)
        {
            var result = await _employeeRepository.AddEmployeeAsync(_mapper.Map<EmployeeEntity>(employee));
            return _mapper.Map<Employee>(result);
        }

        public async Task DeleteEmployeeAsync(string employeeId)
        {
            await _employeeRepository.DeleteEmployeeAsync(employeeId);
        }

        public async Task<bool> EmployeeExistsAsync(string employeeId)
        {
            return await _employeeRepository.EmployeeExistsAsync(employeeId);
        }

        public async Task<Employee?> GetEmployeeAsync(string employeeId)
        {
            var result = await _employeeRepository.GetEmployeeAsync(employeeId);

            if (result == null)
            {
                return null;
            }

            return _mapper.Map<Employee>(result);
        }

        public async Task<ContactInfo?> GetEmployeeContactInfo(string employeeId)
        {
            var result = await _employeeRepository.GetEmployeeContactInfo(employeeId);
            return _mapper.Map<ContactInfo>(result);
        }

        public async Task<IEnumerable<Employee>> GetEmployees(string? employeeType = null)
        {
            var result = await _employeeRepository.GetEmployees(employeeType);
            return _mapper.Map<IEnumerable<Employee>>(result);
        }

        public async Task InactivateEmployeeAsync(string employeeId)
        {
            await _employeeRepository.InactivateEmployeeAsync(employeeId);
        }

        public async Task<Employee> UpdateEmployeeAsync(Employee employee)
        {
            var result = await _employeeRepository.UpdateEmployeeAsync(_mapper.Map<EmployeeEntity>(employee));
            return _mapper.Map<Employee>(result);
        }
    }
}
