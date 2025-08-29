namespace IslamicFace.Application.Features.UserFolder.UpdateUserInfoCommand;

public record UpdateUserInfoCommand(string Id,string fName,string lName, short countryID, short cityID,
    DateOnly dateOfBirth, Gender gender,string? bio, string? PhoneNumber, byte settingId = 3) : ICommand<UpdateUserInfoCommandResponse>;