namespace IslamicFace.Application.Abstractions.IServices.ServiceDTOs;

public class AddReminderInfoForUserResponse
{
    public required Guid Id { get; set; }
    public required string Email { get; set; }
    public required string UserName { get; set; }
    public  string? Message { get; set; }
}
