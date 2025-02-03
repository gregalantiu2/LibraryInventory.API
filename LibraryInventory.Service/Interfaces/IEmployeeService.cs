using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.SharedModels;

namespace LibraryInventory.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees(string? employeeType = null);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task InactivateEmployeeAsync(string employeeId);
        Task DeleteEmployeeAsync(string employeeId);
        Task<Employee> GetEmployeeAsync(string employeeId);
        Task<ContactInfo> GetEmployeeContactInfo(string employeeId);
        Task<bool> EmployeeExistsAsync(string employeeId);
    }
}
