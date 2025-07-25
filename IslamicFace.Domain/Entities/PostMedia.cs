using IslamicFace.Domain.Enums;

namespace IslamicFace.Domain.Entities
{
    public class PostMedia
    {
        public decimal  Id { get; set; }
        public decimal postId { get; set; }
        public MediaType mediaType { get; set; }
        public string? mediaURL { get; set; }

        public Post? Post { get; set; }

    }
}
