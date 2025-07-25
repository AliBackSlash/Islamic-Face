namespace IslamicFace.Infrastructure.EFCore.Entities
{
    public class PostTag
    {
        public int Id { get; set; }
        public decimal postId { get; set; }
        public string? tag { get; set; }

        public Post? Post { get; set; }
    }
}
