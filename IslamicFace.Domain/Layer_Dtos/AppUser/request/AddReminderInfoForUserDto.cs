namespace IslamicFace.Domain.Layer_Dtos.AppUser.request;

public record AddReminderInfoForUserDto(string Name, string Email, string Password, string UserName,
    short CountryId, short CityId, DateOnly DateOfBirth, bool Gender, string? Bio, string? ProfilePictureUrl);
