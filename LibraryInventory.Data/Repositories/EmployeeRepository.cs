using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Entities.Shared;
using LibraryInventory.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryInventory.Data.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly LibraryInventoryDbContext _context;

        public EmployeeRepository(LibraryInventoryDbContext context)
        {
            _context = context;
        }

        public async Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity employee)
        {
            var employeeType = await _context.EmployeeTypes.FirstOrDefaultAsync(e => e.EmployeeTypeId == employee.EmployeeTypeId);

            if (employeeType == null)
            {
                throw new InvalidOperationException($"EmployeeType {employee.EmployeeTypeId} not found");
            }

            employee.EmployeeType = employeeType;
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task DeleteEmployeeAsync(string employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> EmployeeExistsAsync(string employeeId)
        {
            return await _context.Employees.AnyAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<EmployeeEntity?> GetEmployeeAsync(string employeeId)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
        }

        public async Task<ContactInfoEntity?> GetEmployeeContactInfo(string employeeId)
        {
            return await _context.Employees.Where(e => e.EmployeeId == employeeId).Select(e => e.ContactInfo).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<EmployeeEntity>> GetEmployees(string? employeeType = null)
        {
            if (string.IsNullOrEmpty(employeeType))
            {
                return await _context.Employees.ToListAsync();
            }

            return await _context.Employees.Where(e => e.EmployeeType.EmployeeTypeName == employeeType).ToListAsync();
        }

        public async Task InactivateEmployeeAsync(string employeeId)
        {
            var employee = await _context.Employees.FindAsync(employeeId);

            if (employee != null)
            {
                employee.Active = false;

                _context.Employees.Update(employee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<EmployeeEntity> UpdateEmployeeAsync(EmployeeEntity employee)
        {
            _context.Employees.Update(employee);
            await _context.SaveChangesAsync();

            return employee;
        }
    }
}
