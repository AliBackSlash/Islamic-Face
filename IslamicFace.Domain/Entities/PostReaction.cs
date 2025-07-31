namespace IslamicFace.Domain.Entities
{
    public class PostReaction
    {
        public Guid userId { get; set; }
        public Guid postId { get; set; }
        public byte reactTypeID { get; set; }

        public Post? Post { get; set; }        
        public Reaction? Reaction { get; set; }
    }
}
