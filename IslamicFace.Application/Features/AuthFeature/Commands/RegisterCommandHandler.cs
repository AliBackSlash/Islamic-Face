
using IslamicFace.Application.Abstractions.IServices.IdentityServices;

namespace IslamicFace.Application.Features.AuthFeature.Commands;

public class RegisterCommandHandler(IAppUserService _userService) : ICommandHandler<RegisterCommand, RegisterCommandResponse>
{
    public Task<Result<RegisterCommandResponse>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        return _userService.RegisterCredentialAsync(request);
    }
}