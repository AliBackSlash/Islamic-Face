namespace IslamicFace.Domain.Layer_Dtos.AppUser.request;

public record UpdateUserInfoForUserDto(string Id, string fName, string lName, short countryID, short cityID,
    DateOnly dateOfBirth, Gender gender, string? bio, string? PhoneNumber, byte settingId = 3);
