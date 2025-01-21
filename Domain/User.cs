namespace TRUMPet.Domain
{
    public class User : Basedomainmodel
    {
        public int UserID { get; set; } // Primary Key
        public string Username { get; set; } // User's Display Name
        public string Email { get; set; } // User's Email Address
        public string PasswordHash { get; set; } // Securely Stored Password
        public string? Preferences { get; set; } // Serialized User Preferences (e.g., favorite genres)
        public DateTime DateCreated { get; set; } // Account Creation Date
    }
}
