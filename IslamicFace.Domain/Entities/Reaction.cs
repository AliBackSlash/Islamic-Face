using IslamicFace.Domain.Enums;

namespace IslamicFace.Domain.Entities
{
    public class Reaction
    {
        public byte Id { get; set; }
        public ReactType ReactType { get; set; }

        public PostReaction? PostReaction { get; set; }
    }
}
