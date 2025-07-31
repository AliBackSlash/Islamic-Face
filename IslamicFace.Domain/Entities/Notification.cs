using IslamicFace.Domain.Enums;

namespace IslamicFace.Domain.Entities;

public class Notification
{
    public Guid Id { get; set; }
    public string UserId { get; set; } // المستلم
    public string? TriggeredByUserId { get; set; } // من سبّب الإشعار (اختياري)

    public NotificationType Type { get; set; }
    public string? Message { get; set; } // نص مخصص (اختياري)

    public Guid? PostId { get; set; } // لو الإشعار متعلق بمنشور
    public Guid? CommentId { get; set; }

    public bool IsRead { get; set; } = false;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

  /*  public AppUser User { get; set; } // Navigation
    public AppUser? TriggeredByUser { get; set; } // Navigation*/
}
