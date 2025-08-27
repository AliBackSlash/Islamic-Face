namespace IslamicFace.Domain.Layer_Dtos.AppUser.response;

public record UpdateTheRestOfTheUser_DataResponseDto(Guid Id,string fName, string lName, short? countryID, short? cityID,
    DateOnly? dateOfBirth, bool gender, string? profilePictureURL, string? bio, string? PhoneNumber, byte? settingId);
