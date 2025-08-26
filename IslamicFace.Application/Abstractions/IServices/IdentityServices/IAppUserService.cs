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
    Task<Result<string>> ConfirmEmailAsync(string userId, string token);
    Task<Result<string>> ChangePasswordAsync(string Id, string CurrentPassword, string Password);
    Task<Result<bool>> IsEmailNotTakenAsync(string email);
    Task<Result<bool>> IsUserNameNotTakenAsync(string userName);
    Task<Result> AddUserToRoleAsync(Guid userId, UserRole role);
    Task<Result<string>> GenerateEmailConfirmationTokenAsync(string email);
    Task<Result<string>> GenerateRestPasswordTokenAsync(string email);
    Task<Result<string>> ResetPasswordAsync(string Email, string token, string Password);
    Task<Result<bool>> DeleteUserAsync(Guid userId);
}
