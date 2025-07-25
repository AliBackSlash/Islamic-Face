namespace IslamicFace.Domain.Entities
{
    public class PostTag
    {
        public decimal Id { get; set; }
        public decimal postId { get; set; }
        public string? tag { get; set; }

        public Post? Post { get; set; }
    }
}
