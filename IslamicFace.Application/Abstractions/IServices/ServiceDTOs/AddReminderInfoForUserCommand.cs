namespace IslamicFace.Application.Abstractions.IServices.ServiceDTOs;

public class AddReminderInfoForUserCommand
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public required string UserName { get; set; }
    public short CountryId { get; set; }
    public short CityId { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public bool Gender { get; set; }
    public string? Bio { get; set; }
    public string? ProfilePictureUrl { get; set; }
}
