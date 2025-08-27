namespace IslamicFace.Application.Features.UserFolder.AddTheRestOfTheUser_DataCommand;

public class AddTheRestOfTheUser_DataCommandResponse
{
    public Guid Id { get; set; }
    public string fName { get; set; } = default!;
    public string lName { get; set; } = default!;
    public short? countryID { get; set; }
    public short? cityID { get; set; }
    public DateOnly? dateOfBirth { get; set; }
    public bool gender { get; set; }
    public string? profilePictureURL { get; set; }
    public string? bio { get; set; }
    public string? PhoneNumber { get; set; }
    public byte? settingId { get; set; }
}

