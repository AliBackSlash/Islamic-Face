namespace Islamic_Face_Data_Access.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string? name { get; set; }

        public User? User { get; set; }
    }
}
