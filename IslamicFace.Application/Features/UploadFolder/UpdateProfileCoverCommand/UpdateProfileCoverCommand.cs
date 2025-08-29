namespace IslamicFace.Application.Features.UploadFolder.UpdateProfileCoverCommand;

public record UpdateProfileCoverCommand(string userId, string ProfileImagePath,string rootPath) : ICommand;
