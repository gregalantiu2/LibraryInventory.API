using LibraryInventory.Model.Models.Person;

namespace LibraryInventory.Service.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> SearchEmployeesAsync(string searchTerm);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<Employee> UpdateEmployeeAsync(Employee employee);
        Task InactivateEmployeeAsync(string employeeId);
        Task DeleteEmployeeAsync(string employeeId);
        Task<Employee> GetEmployeeAsync(string employeeId);
        Task<bool> EmployeeExistsAsync(string employeeId);
    }
}
