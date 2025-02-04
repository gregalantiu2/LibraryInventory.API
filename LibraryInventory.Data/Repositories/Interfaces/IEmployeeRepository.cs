using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Entities.Shared;
using LibraryInventory.Model.PersonModels;
using LibraryInventory.Model.SharedModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Data.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeEntity>> GetEmployees(string? employeeType = null);
        Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity employee);
        Task<EmployeeEntity> UpdateEmployeeAsync(EmployeeEntity employee);
        Task InactivateEmployeeAsync(string employeeId);
        Task DeleteEmployeeAsync(string employeeId);
        Task<EmployeeEntity> GetEmployeeAsync(string employeeId);
        Task<ContactInfoEntity> GetEmployeeContactInfo(string employeeId);
        Task<bool> EmployeeExistsAsync(string employeeId);
    }
}
