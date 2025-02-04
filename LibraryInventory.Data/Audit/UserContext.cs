using LibraryInventory.Data.Audit.Interfaces;

namespace LibraryInventory.Data.Audit
{
    public class UserContext : IUserContext
    {
        public string? UserId { get; set; }
    }
}
