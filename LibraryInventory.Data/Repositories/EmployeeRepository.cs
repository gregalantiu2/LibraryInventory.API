using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Entities.Shared;
using LibraryInventory.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity employee)
        {
            throw new NotImplementedException();
        }

        public Task DeleteEmployeeAsync(string employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EmployeeExistsAsync(string employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeEntity> GetEmployeeAsync(string employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<ContactInfoEntity> GetEmployeeContactInfo(string employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<EmployeeEntity>> GetEmployees(string? employeeType = null)
        {
            throw new NotImplementedException();
        }

        public Task InactivateEmployeeAsync(string employeeId)
        {
            throw new NotImplementedException();
        }

        public Task<EmployeeEntity> UpdateEmployeeAsync(EmployeeEntity employee)
        {
            throw new NotImplementedException();
        }
    }
}
