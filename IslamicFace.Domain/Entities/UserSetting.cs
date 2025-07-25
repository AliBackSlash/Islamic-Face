using IslamicFace.Domain.Enums;

namespace IslamicFace.Domain.Entities
{
    public class UserSetting
    {
        public byte Id { get; set; }
        public GenderOfFriends GenderOfFriends { get; set; }
        public User? User { get; set; }
    }
}
