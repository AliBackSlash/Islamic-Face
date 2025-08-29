namespace IslamicFace.Presentation.API.Controllers.v1.UploadsController.DTOs;

public record UpdateProfileCoverModel(string userId, IFormFile Image);