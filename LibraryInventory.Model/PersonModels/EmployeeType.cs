namespace LibraryInventory.Model.PersonModels
{
    public class EmployeeType
    {
        private readonly int? _employeeTypeId;
        private string? _employeeTypeName;

        public EmployeeType(string? employeeTypeName = null, int? employeeTypeId = null)
        {
            _employeeTypeId = employeeTypeId;
            _employeeTypeName = employeeTypeName;
        }
        public int? EmployeeTypeId
        {
            get { return _employeeTypeId; }
        }
        public string? EmployeeTypeName
        {
            get { return _employeeTypeName; }
            set { _employeeTypeName = value; }
        }
    }
}
