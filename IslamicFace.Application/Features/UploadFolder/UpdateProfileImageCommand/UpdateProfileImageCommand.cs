namespace IslamicFace.Application.Features.UploadFolder.UpdateProfileImageCommand;

public record UpdateProfileImageCommand(string userId,string ProfileImagePath, string rootPath) : ICommand;
