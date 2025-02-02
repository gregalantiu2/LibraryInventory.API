using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryInventory.Model.Models.Person
{
    public class EmployeeType
    {
        private readonly int _employeeTypeId;
        private string _employeeTypeName;

        // Encapsulate the fields
        public EmployeeType(string employeeTypeName)
        {
            _employeeTypeName = employeeTypeName;
        }
        public int EmployeeTypeId
        {
            get { return _employeeTypeId; }
        }
        public string EmployeeTypeName
        {
            get { return _employeeTypeName; }
            set { _employeeTypeName = value; }
        }
    }
}
