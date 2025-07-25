using IslamicFace.Infrastructure.EFCore.Enums;

namespace IslamicFace.Infrastructure.EFCore.Entities
{
    public class Reaction
    {
        public byte Id { get; set; }
        public ReactType ReactType { get; set; }

        public PostReaction? PostReaction { get; set; }
    }
}
