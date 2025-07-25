using IslamicFace.Infrastructure.EFCore.Enums;

namespace IslamicFace.Infrastructure.EFCore.Entities
{
    public class UserSetting
    {
        public byte Id { get; set; }
        public GenderOfFriends GenderOfFriends { get; set; }
        public User? User { get; set; }
    }
}
