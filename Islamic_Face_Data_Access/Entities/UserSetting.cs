using Islamic_Face_Data_Access.Enums;

namespace Islamic_Face_Data_Access.Entities
{
    public class UserSetting
    {
        public byte Id { get; set; }
        public GenderOfFriends GenderOfFriends { get; set; }
        public User? User { get; set; }
    }
}
