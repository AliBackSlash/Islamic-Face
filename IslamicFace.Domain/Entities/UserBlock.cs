namespace IslamicFace.Domain.Entities;

public class UserBlock
{
    public Guid BlockerId { get; set; } 
    public Guid BlockedId { get; set; } 
    public bool IsBlocked { get; set; }
    public DateTime CreatedAt { get; set; }
}
