namespace IslamicFace.Application.Features.UserFolder.UpdateUserInfoCommand;

public class UpdateUserInfoCommandResponse
{
    public Guid Id { get; set; }
    public string fName { get; set; } = default!;
    public string lName { get; set; } = default!;
    public short? countryID { get; set; }
    public short? cityID { get; set; }
    public DateOnly? dateOfBirth { get; set; }
    public Gender gender { get; set; }
    public string? profilePictureURL { get; set; }
    public string? profileCoverURL { get; set; }
    public string? bio { get; set; }
    public string? PhoneNumber { get; set; }
    public byte? settingId { get; set; }
}

