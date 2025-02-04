namespace LibraryInventory.Model.RequestModels
{
    public class EmployeeRequest
    {
        public string? EmployeeId { get; set; } = null;
        public required int EmployeeTypeId { get; set; }
        public required string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public required string LastName { get; set; }
        public required string PhoneNumber { get; set; }
        public required string Email { get; set; }
        public required string Street { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string ZipCode { get; set; }
        public required string Country { get; set; }
    }
}
