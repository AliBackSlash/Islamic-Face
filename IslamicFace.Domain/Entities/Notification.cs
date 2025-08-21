using IslamicFace.Domain.Enums;

namespace IslamicFace.Domain.Entities;

public class Notification
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; } 
    public Guid TriggeredByUserId { get; set; } 
    public NotificationType Type { get; set; }
    public Guid? PostId { get; set; } 
    public Guid? CommentId { get; set; } 
    public bool IsRead { get; set; }
    public DateTime CreatedAt { get; set; }
    public required string NotificationURL { get; set; }
}
