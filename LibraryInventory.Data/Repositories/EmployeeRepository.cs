using LibraryInventory.Data.Entities.Person;
using LibraryInventory.Data.Entities.Shared;
using LibraryInventory.Data.Repositories.Interfaces;
using LibraryInventory.Model.PersonModels;
using Microsoft.EntityFrameworkCore;

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
            var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);

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
            var rowsAffected = await _context.Employees.Where(e => e.EmployeeId == employeeId)
                .ExecuteUpdateAsync(u =>
                    u.SetProperty(emp => emp.Active, false));

            if (rowsAffected == 0)
            {
                throw new InvalidOperationException($"Employee {employeeId} not found");
            }
        }

        public async Task<EmployeeEntity> UpdateEmployeeAsync(EmployeeEntity updateEmployee)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var employee = await _context.Employees.FirstOrDefaultAsync(e => e.EmployeeId == updateEmployee.EmployeeId);

                if (employee == null)
                {
                    throw new InvalidOperationException($"Employee {updateEmployee.EmployeeId} not found");
                }

                employee.FirstName = updateEmployee.FirstName;
                employee.MiddleName = updateEmployee.MiddleName;
                employee.LastName = updateEmployee.LastName;
                employee.EmployeeTypeId = updateEmployee.EmployeeTypeId;

                var contactInfo = await _context.ContactInfos.FirstOrDefaultAsync(c => c.ContactInfoId == employee.ContactInfoId);

                if (contactInfo == null)
                {
                    await _context.ContactInfos.AddAsync(updateEmployee.ContactInfo);
                    await _context.SaveChangesAsync();
                    employee.ContactInfoId = updateEmployee.ContactInfo.ContactInfoId;
                }
                else
                {
                    contactInfo.Email = updateEmployee.ContactInfo.Email;
                    contactInfo.PhoneNumber = updateEmployee.ContactInfo.PhoneNumber;
                    contactInfo.Street = updateEmployee.ContactInfo.Street;
                    contactInfo.City = updateEmployee.ContactInfo.City;
                    contactInfo.State = updateEmployee.ContactInfo.State;
                    contactInfo.ZipCode = updateEmployee.ContactInfo.ZipCode;
                    contactInfo.Country = updateEmployee.ContactInfo.Country;
                }

                var lookupEmployeeType = await _context.EmployeeTypes.FirstOrDefaultAsync(e => e.EmployeeTypeId == employee.EmployeeTypeId);

                if (lookupEmployeeType == null)
                {
                    throw new InvalidOperationException($"EmployeeType {updateEmployee.EmployeeTypeId} not found");
                }

                employee.EmployeeType = lookupEmployeeType;

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return employee;
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
