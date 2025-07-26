using IslamicFace.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IslamicFace.Domain.Entities
{
    public class User
    {

        public Guid Id { get; set; }
        public required string name { get; set; }
        public required string email { get; set; }
        public required string password { get; set; }
        public required string userName { get; set; }
        public short countryID { get; set; }
        public short cityID { get; set; }
        public DateOnly dateOfBirth { get; set; }
        public DateTime joinDate { get; set; }
        public bool gender { get; set; }
        public required string profilePictureURL { get; set; }
        public required string bio {  get; set; }
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
