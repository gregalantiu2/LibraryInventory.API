using LibraryInventory.Model.Models.Person;

namespace LibraryInventory.Service.Interfaces
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> SearchEmployees(string searchTerm);
        Employee AddEmployee(Employee employee);
        Employee UpdateItem(Employee employee);
        void InactivateEmployee(int employeeId);
        Employee GetEmployee(string employeeId);
    }
}
