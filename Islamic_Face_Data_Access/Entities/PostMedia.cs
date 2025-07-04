using Islamic_Face_Data_Access.Enums;

namespace Islamic_Face_Data_Access.Entities
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
