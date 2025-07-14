using Islamic_Face_Data_Access.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Islamic_Face_Data_Access.Entities
{
    public class User
    {

        public int Id { get; set; }
        public string? name { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public string? userName { get; set; }
        public int countryID { get; set; }
        public string? city { get; set; }
        public DateOnly dateOfBirth { get; set; }
        public DateTime joinDate { get; set; }
        public bool gender { get; set; }
        public string? profilePictureURL { get; set; }
        public string? bio {  get; set; }
        public UserTypes userType { get; set; }

        public byte settingId { get; set; }

        public Country? Country { get; set; }
        public ICollection<FriendRequest>  senderRequests { get; set; } = new List<FriendRequest>();
        
        public ICollection<FriendRequest>  RecoversRequests { get; set; } = new List<FriendRequest>();
        
        public ICollection<PostReaction> PostReactions { get; set; } = new List<PostReaction>();
        public ICollection<PostComment> Comments { get; set; } = new List<PostComment>();
        public ICollection<Post> Posts { get; set; } = new List<Post>();
        public UserSetting? UserSetting { get; set; }
    }


}
