namespace IslamicFace.Domain.Entities;

public class UserBlock
{
    public Guid Id { get; set; }
    public string BlockerId { get; set; } // for AppUser
    public string BlockedId { get; set; } // for AppUser

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

/*    public AppUser Blocker { get; set; } = null!;
    public AppUser Blocked { get; set; } = null!;*/
}
