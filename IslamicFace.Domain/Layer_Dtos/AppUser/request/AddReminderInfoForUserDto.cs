namespace IslamicFace.Domain.Layer_Dtos.AppUser.request;

public record AddTheRestOfTheUser_DataForUserDto(string Id, string fName, string lName, short countryID, short cityID,
    DateOnly dateOfBirth, bool gender, string? profilePictureURL, string? bio, string? PhoneNumber, byte settingId = 3);
