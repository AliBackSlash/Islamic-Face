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
public class AppUserService(UserManager<AppUser> _userManager,JWT _jwt) : IAppUserService
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

        var Token = await CreateJWTToken(user);

        return Result.Success(new RegisterResponseDto(user.Id, await CreateJWTToken(user)));
    }
    private async Task<string> CreateJWTToken(AppUser appUser)
    {
        var userClaims = await _userManager.GetClaimsAsync(appUser);
        var roles = await _userManager.GetRolesAsync(appUser);
        var roleClaims = roles.Select(r => new Claim("roles", r)).ToList();

        var claims = new List<Claim>
    {
        new Claim(JwtRegisteredClaimNames.Sub, appUser.UserName ?? ""),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(JwtRegisteredClaimNames.Email, appUser.Email ?? ""),
        new Claim(JwtRegisteredClaimNames.UniqueName, appUser.UserName ?? ""),
        new Claim("UType", appUser.userType.ToString()),
        new Claim("uid", appUser.Id.ToString())
    };

        claims.AddRange(userClaims);
        claims.AddRange(roleClaims);

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.SigningKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwt.Issuer,
            audience: _jwt.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwt.Duration),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    private Task<(string? Email, string? UserName, List<string> Roles, DateTime Expiration)> GetInfoFromToken(string token)
    {
        var handler = new JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);

        var userName = jwtToken.Claims
            .FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.UniqueName)?.Value;

        var email = jwtToken.Claims
            .FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Email)?.Value;

        var roles = jwtToken.Claims
            .Where(c => c.Type == "roles")
            .Select(c => c.Value)
            .ToList();

        var expiration = jwtToken.ValidTo;

        return Task.FromResult((email, userName, roles, expiration));
    }
    public async Task<Result<LoginResponseDto>> LoginAsync(LoginDto dto, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(dto.UserNameOrEmail);
        if (user is not null)
        {
            string token = await CreateJWTToken(user);
            var tokenInfo = await GetInfoFromToken(token);
            return Result.Success(new LoginResponseDto(token,tokenInfo.Email,tokenInfo.UserName,tokenInfo.Roles,tokenInfo.Expiration));
        }

        user = await _userManager.FindByNameAsync(dto.UserNameOrEmail);
        if (user is not null)
            if (await _userManager.CheckPasswordAsync(user, dto.Password!))
            {
                string token = await CreateJWTToken(user);
                var tokenInfo = await GetInfoFromToken(token);
                return Result.Success(new LoginResponseDto(token, tokenInfo.Email, tokenInfo.UserName, tokenInfo.Roles, tokenInfo.Expiration));
            }

        return Result.Failure<LoginResponseDto>(new Error("Wrong Credentials", "Invalid UserName Or Password", ErrorType.NotFound));
    }
    public Task<Result<AddReminderInfoForUserResponseDto>> AddReminderInfoForUserAsync(AddReminderInfoForUserDto dto, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
    public async Task<Result> ConfirmEmailAsync(Guid userId, string token, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user is null)
            Result.Failure(Error.NotFound("Not Found", $"User with id {userId} not found"));
           
        var ConfirmResult = await _userManager.ConfirmEmailAsync(user!, token);
        if (!ConfirmResult.Succeeded)
            return Result.Failure<RegisterResponseDto>(new Error("Create Errors", string.Join(", ", ConfirmResult.Errors.Select(e => e.Description)), ErrorType.Create));

        return Result.Success();
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
    public async Task<Result> AddUserToRoleAsync(Guid userId, UserRole role)
    {
        AppUser? user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
            return Result.Failure(new Error("(Add Role) User Not Found", "", ErrorType.NotFound));

        var roleResult = await _userManager.AddToRoleAsync(user, role.ToString());
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

