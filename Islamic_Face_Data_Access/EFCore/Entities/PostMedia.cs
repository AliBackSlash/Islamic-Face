using IslamicFace.Infrastructure.EFCore.Enums;

namespace IslamicFace.Infrastructure.EFCore.Entities
{
    public class PostMedia
    {
        public int  Id { get; set; }
        public decimal postId { get; set; }
        public MediaType mediaType { get; set; }
        public string? mediaURL { get; set; }

        public Post? Post { get; set; }

    }
}
