
using IslamicFace.Application.Features.AuthFeature.Commands.ResetPasswordCommand;

namespace IslamicFace.Application.Features.UserFolder.ChangePasswordCommand;

internal class ChangePasswordCommandHandler(IAppUserService userService) : ICommandHandler<ChangePasswordCommand, ChangePasswordCommandResponse>
{
    public async Task<Result<ChangePasswordCommandResponse>> Handle(ChangePasswordCommand command, CancellationToken cancellationToken)
    {
       var changeResult = await userService.ChangePasswordAsync(command.id, command.currentPassword, command.newPassword);
        if (changeResult.IsFailure)
            return Result.Failure<ChangePasswordCommandResponse>(changeResult.Errors);

        return Result.Success(new ChangePasswordCommandResponse { token = changeResult.Value });
    }
}
