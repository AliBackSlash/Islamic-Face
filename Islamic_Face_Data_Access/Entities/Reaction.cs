using Islamic_Face_Data_Access.Enums;

namespace Islamic_Face_Data_Access.Entities
{
    public class Reaction
    {
        public byte Id { get; set; }
        public ReactType ReactType { get; set; }

        public PostReaction? PostReaction { get; set; }
    }
}
