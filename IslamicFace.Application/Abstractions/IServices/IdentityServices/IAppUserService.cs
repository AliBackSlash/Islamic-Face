using IslamicFace.Application.Features.AuthFeature.Commands;
using IslamicFace.Domain.Enums;
using IslamicFace.Domain.Layer_Dtos.AppUser.request;
using IslamicFace.Domain.Layer_Dtos.AppUser.response;

namespace IslamicFace.Application.Abstractions.IServices.IdentityServices;
public interface IAppUserService
{
    Task<Result<RegisterResponseDto>> RegisterCredentialAsync(RegisterUserDto dto, CancellationToken cancellationToken);
    Task<Result<AddReminderInfoForUserResponseDto>> AddReminderInfoForUserAsync(AddReminderInfoForUserDto dto, CancellationToken cancellationToken);
    Task<Result<LoginResponseDto>> LoginAsync(LoginDto dto, CancellationToken cancellationToken);
    Task<Result> ConfirmEmailAsync(Guid userId, string token, CancellationToken cancellationToken);
    Task<Result<bool>> IsEmailNotTakenAsync(string email);
    Task<Result<bool>> IsUserNameNotTakenAsync(string userName);
    Task<Result> AddUserToRoleAsync(Guid userId, UserRole role);
    Task<Result<string>> GenerateEmailConfirmationTokenAsync(Guid userId,CancellationToken cancellationToken);
    Task<Result<bool>> DeleteUserAsync(Guid userId);
}
