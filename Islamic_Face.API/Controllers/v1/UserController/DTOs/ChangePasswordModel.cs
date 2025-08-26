namespace IslamicFace.Presentation.API.Controllers.v1.UserController.DTOs;

public record ChangePasswordModel(string Id, string CurrentPassword, string Password, string ConfermPassword);