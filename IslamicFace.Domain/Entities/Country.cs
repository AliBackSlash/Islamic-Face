namespace IslamicFace.Domain.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string? name { get; set; }

        public User? User { get; set; }
    }
}
