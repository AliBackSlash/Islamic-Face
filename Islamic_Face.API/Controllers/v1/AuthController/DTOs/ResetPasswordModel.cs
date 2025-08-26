
namespace IslamicFace.Presentation.API.Controllers.v1.AuthController.DTOs;

public record ResetPasswordModel(string Email, string token, string Password, string ConfermPassword);
