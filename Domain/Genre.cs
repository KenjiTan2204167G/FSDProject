namespace TRUMPet.Domain
{
    public class Genre : Basedomainmodel
    {
        public int GenreID { get; set; } // Primary Key
        public string Name { get; set; } // Genre Name (e.g., Pop, Rock)
        public string? Description { get; set; } // Optional Description
    }
}
