namespace IslamicFace.Domain.Entities
{
    public class Post
    {
        public decimal Id { get; set; }
        public string? postText { get; set; }
        public int userId { get; set; }
        public DateTime createdAt { get; set; }


        public User? User { get; set; }
        public ICollection<PostReaction> PostReactions { get; set; } = new List<PostReaction>();
        public ICollection<PostComment> PostComments { get; set; } = new List<PostComment>();
        public ICollection<PostMedia> PostMedias { get; set; } = new List<PostMedia>();
        public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
    }
}
