using IslamicFace.Application.Features.AuthFeature.Commands;
using IslamicFace.Domain.Abstractions.IServices;
using IslamicFace.Domain.JWT;
using IslamicFace.Domain.Layer_Dtos.AppUser.request;
using IslamicFace.Domain.Layer_Dtos.AppUser.response;
using IslamicFace.Infrastructure.EFCore.IdentityUser;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Web;

namespace IslamicFace.Infrastructure.Services.IdentityServices;
public class AppUserService(UserManager<AppUser> _userManager,JWT _jwt,IEmailService emailService) : IAppUserService
{

    public async Task<Result<RegisterResponseDto>> RegisterCredentialAsync(RegisterUserDto reg_info, CancellationToken cancellationToken)
    {
       
        AppUser user = new()
        {
            UserName = reg_info.UserName,
            Email = reg_info.Email
        };

        var createResult = await _userManager.CreateAsync(user, reg_info.Password);
        if (!createResult.Succeeded)
            return Result.Failure<RegisterResponseDto>(new Error("Create Errors", string.Join(", ", createResult.Errors.Select(e => e.Description)), ErrorType.Create));

        var jwtSecurityToken = await CreateJWTToken(user);

        return Result.Success(new RegisterResponseDto(user.Id,new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)));
    }
    public async Task<JwtSecurityToken> CreateJWTToken(AppUser appUser)
    {
        var userClaims = await _userManager.GetClaimsAsync(appUser);
        var roles = await _userManager.GetRolesAsync(appUser);
        var roleClaims = new List<Claim>();

        foreach (var role in roles)
            roleClaims.Add(new Claim("roles", role));

        var claims = new[]
        {
             new Claim(JwtRegisteredClaimNames.Sub,appUser.UserName),
             new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
             new Claim(JwtRegisteredClaimNames.Email,appUser.Email ?? ""),
             new Claim(JwtRegisteredClaimNames.UniqueName,appUser.UserName),
             new Claim(JwtRegisteredClaimNames.Exp,DateTime.Now.AddMinutes(_jwt.Duration).ToString()),
             new Claim("UType",appUser.userType.ToString()),

             new Claim("uid",appUser.Id.ToString()),

        }.Union(userClaims)
         .Union(roleClaims);

        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SigningKey));
        var SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

        return new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.Duration),
            signingCredentials: SigningCredentials
            );


    }
    public Task<Result<AddReminderInfoForUserResponseDto>> AddReminderInfoForUserAsync(AddReminderInfoForUserDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public Task<Result<string>> LoginAsync(LoginDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public Task<Result> ConfirmEmailAsync(Guid userId, string token, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public async Task<Result<bool>> IsEmailNotTakenAsync(string email)
    {
        if (await _userManager.FindByEmailAsync(email) is not null)
            return Result.Failure<bool>(new Error("Validation error", "Invalid UserName Or Email", ErrorType.Validation));

        return Result.Success(true);
    }
    public async Task<Result<bool>> IsUserNameNotTakenAsync(string userName)
    {
        if (await _userManager.FindByNameAsync(userName) is not null)
            return Result.Failure<bool>(new Error("Validation error", "Invalid UserName Or Email", ErrorType.Validation));

        return Result.Success(true);
    }
    public async Task<Result> AddUserToRoleAsync(Guid userId, string role)
    {
        AppUser? user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
            return Result.Failure(new Error("(Add Role) User Not Found", "", ErrorType.NotFound));

        var roleResult = await _userManager.AddToRoleAsync(user, "User");
        if (!roleResult.Succeeded)
        {
            await _userManager.DeleteAsync(user);
            return Result.Failure<RegisterResponseDto>(new Error("Role Errors", string.Join(", ", roleResult.Errors.Select(e => e.Description)), ErrorType.Conflict));
        }

        return Result.Success();

    }
    public async Task<Result<string>> GenerateEmailConfirmationTokenAsync(Guid userId, CancellationToken cancellationToken)
    {
        AppUser? user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
            return Result.Failure<string>(new Error("(Generate Email Confirmation) User Not Found", "", ErrorType.NotFound));

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var encodedToken = HttpUtility.UrlEncode(token);

        if (string.IsNullOrEmpty(encodedToken))
              return Result.Failure<string>(new Error("(Generate Email Confirmation) Error", "", ErrorType.NotFound));

        return Result.Success($"https://localhost:7145/confirm-email?userId={user.Id}&token={encodedToken}");
    }
    public async Task<Result<bool>> DeleteUserAsync(Guid userId)
    {
        AppUser? user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
            return Result.Failure<bool>(new Error("(Delete User) User Not Found", "", ErrorType.NotFound));

        var deleteResult = await _userManager.DeleteAsync(user);
        if(deleteResult.Succeeded)
            return Result.Success(true);

        return Result.Failure<bool>(new Error("(Delete User) Errors", string.Join(", ", deleteResult.Errors.Select(e => e.Description)), ErrorType.Delete));
    }
}
