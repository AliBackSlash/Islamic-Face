namespace IslamicFace.Application.Features.UploadFolder.UpdateProfileCoverCommand;

internal class UpdateProfileCoverCommandHandler(IAppUserService userService) : ICommandHandler<UpdateProfileCoverCommand>
{
    public async Task<Result> Handle(UpdateProfileCoverCommand command, CancellationToken cancellationToken)
    {
        return await userService.UpdateProfileCoverAsync(command.userId, command.ProfileImagePath,command.rootPath);
    }
}
