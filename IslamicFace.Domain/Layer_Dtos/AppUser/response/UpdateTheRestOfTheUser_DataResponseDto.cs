namespace IslamicFace.Domain.Layer_Dtos.AppUser.response;

public record UpdateUserInfoResponseDto(Guid Id,string fName, string lName, short? countryID, short? cityID,
    DateOnly? dateOfBirth, Gender gender, string? bio, string? PhoneNumber, byte? settingId);
