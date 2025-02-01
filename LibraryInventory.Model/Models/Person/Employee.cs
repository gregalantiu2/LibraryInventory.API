using LibraryInventory.Model.Enums;
using LibraryInventory.Model.Models.Shared;

namespace LibraryInventory.Model.Models.Person
{
    public class Employee : Person
    {
        private readonly string _employeeId;
        private EmployeeType _employeeType;
        public Employee(string firstName, string lastName, ContactInfo contactinfo) : base(firstName, lastName, contactinfo)
        {
        }
        public string EmployeeId
        {
            get { return _employeeId; }
        }
        public EmployeeType EmployeeType
        {
            get { return _employeeType; }
            set { _employeeType = value; }
        }
    }
}
