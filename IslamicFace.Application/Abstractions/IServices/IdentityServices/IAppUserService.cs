using IslamicFace.Application.Features.AuthFeature.Commands;

namespace IslamicFace.Application.Abstractions.IServices.IdentityServices;
public interface IAppUserService
{
    Task<Result<RegisterCommandResponse>> RegisterCredentialAsync(RegisterCommand command);
    Task<Result<AddReminderInfoForUserResponse>> AddReminderInfoForUserAsync(AddReminderInfoForUserCommand command);
    Task<Result<LoginUserResponse>> LoginAsync(RegisterCommand command);
    Task<Result> ConfirmEmailAsync(Guid userId, string token);
}
