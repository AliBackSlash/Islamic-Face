namespace IslamicFace.Infrastructure.Services.IdentityServices;

public class AppUserService : IAppUserService
{
    public Task<RegisterCredentialUserResponse> RegisterCredentialAsync(CredentialUserCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<AddReminderInfoForUserResponse> AddReminderInfoForUserAsync(AddReminderInfoForUserCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<LoginUserResponse> LoginAsync(CredentialUserCommand command)
    {
        throw new NotImplementedException();
    }

}
