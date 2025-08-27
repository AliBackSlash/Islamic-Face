namespace IslamicFace.Presentation.API.Controllers.v1.UserController.DTOs;

    public record AddUserModel(string Id,string fName, string lName, short countryID, short cityID,
    DateOnly dateOfBirth, bool gender, IFormFile? profilePictureURL, string? bio, string? PhoneNumber, byte settingId = 3);
