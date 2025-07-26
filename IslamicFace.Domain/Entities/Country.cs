namespace IslamicFace.Domain.Entities
{
    public class Country
    {
        public short Id { get; set; }
        public required string Name_ENG { get; set; } // for city name in English
        public required string Name_ARB { get; set; } // for city name in Arabic
        public User? User { get; set; }

        public ICollection<City> Cities { get; set; } = new List<City>();
    }
}
