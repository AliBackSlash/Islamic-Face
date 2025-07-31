namespace IslamicFace.Application.Abstractions.IServices.IdentityServices;
public interface IAppUserService
{
    Task<RegisterCredentialUserResponse> RegisterCredentialAsync(CredentialUserCommand command);
    Task<AddReminderInfoForUserResponse> AddReminderInfoForUserAsync(AddReminderInfoForUserCommand command);
    Task<LoginUserResponse> LoginAsync(CredentialUserCommand command);
}
