namespace TRUMPet.Domain
{
    public class Staff
    {
        public int StaffID { get; set; }  // Primary Key
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty; // Securely stored password
        public string Role { get; set; } = "Staff"; // Default role (e.g., Admin, Manager, Support)
        public DateTime DateCreated { get; set; } = DateTime.UtcNow; // Account Creation Date
    }
}
