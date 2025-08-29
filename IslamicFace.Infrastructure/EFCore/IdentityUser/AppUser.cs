using Microsoft.AspNetCore.Identity;

namespace IslamicFace.Infrastructure.EFCore.IdentityUser;

public class AppUser : IdentityUser<Guid>
{

    public string? fName { get; set; }
    public string? lName { get; set; }
    public short? countryID { get; set; }
    public short? cityID { get; set; }
    public DateOnly? dateOfBirth { get; set; }
    public DateTime joinDate { get; set; }
    public Gender gender { get; set; }
    public string? profilePictureURL { get; set; }
    public string? profileCoverURL { get; set; }
    public  string? bio {  get; set; }
    public byte? settingId { get; set; }
    public Country? Country { get; set; }
    public City? City {  get; set; }
    public ICollection<FriendRequest>  senderRequests { get; set; } = new List<FriendRequest>();
    
    public ICollection<FriendRequest>  RecoversRequests { get; set; } = new List<FriendRequest>();
    
    public ICollection<PostReaction> PostReactions { get; set; } = new List<PostReaction>();
    public ICollection<PostComment> Comments { get; set; } = new List<PostComment>();
    public ICollection<Post> Posts { get; set; } = new List<Post>();
    public ICollection<UserInterestField> UserInterestFields { get; set; } = new List<UserInterestField>();
    public ICollection<UserBlock> UserBlockedFrom { get; set; } = new List<UserBlock>();
    public ICollection<UserBlock> UserBlockedUsers { get; set; } = new List<UserBlock>();
    public ICollection<Notification> TriggerNotifications { get; set; } = new List<Notification>();
    public ICollection<Notification> ReceiveNotifications { get; set; } = new List<Notification>();


    public UserSetting? UserSetting { get; set; }
}
