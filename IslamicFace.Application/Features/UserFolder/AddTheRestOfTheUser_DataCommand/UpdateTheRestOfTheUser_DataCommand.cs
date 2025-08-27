namespace IslamicFace.Application.Features.UserFolder.AddTheRestOfTheUser_DataCommand;

public record AddTheRestOfTheUser_DataCommand(string Id,string fName,string lName, short countryID, short cityID,
    DateOnly dateOfBirth, bool gender, string? profilePictureURL, string? bio, string? PhoneNumber, byte settingId = 3) : ICommand<AddTheRestOfTheUser_DataCommandResponse>;