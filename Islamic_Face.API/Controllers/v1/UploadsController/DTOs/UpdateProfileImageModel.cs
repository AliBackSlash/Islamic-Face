namespace IslamicFace.Presentation.API.Controllers.v1.UploadsController.DTOs;

public record UpdateProfileImageModel(string userId, IFormFile Image);
