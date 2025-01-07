namespace TRUMPet.Domain
{
    public class Song : Basedomainmodel
    {
        public int SongID { get; set; }
        public int GenreID { get; set; }
        public int ArtistID { get; set; }
    }
}
