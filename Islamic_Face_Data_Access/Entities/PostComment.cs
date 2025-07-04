namespace Islamic_Face_Data_Access.Entities
{
    public class PostComment
    {
        public int Id { get; set; }
        public int userId { get; set; }
        public decimal postId { get; set; }
        public int? ParentCommentID { get; set; }
        public string? Comment { get; set; }
        public int reactLikeCount { get; set; }
        public DateTime createdAt { get; set; }

        public ICollection<PostComment>? Post_Comments { get; set; } = new List<PostComment>();
        public PostComment? comment { get; set; }
        public User? User { get; set; }
        public Post? Post { get; set; }

    }
}
