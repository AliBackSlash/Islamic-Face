namespace IslamicFace.Domain.Entities
{
    public class PostReaction
    {
        public int userId { get; set; }
        public decimal postId { get; set; }
        public byte reactTypeID { get; set; }

        public User? User { get; set; }
        public Post? Post { get; set; }        
        public Reaction? Reaction { get; set; }
    }
}
