using IslamicFace.Application.Features.AuthFeature.Commands;
using IslamicFace.Domain.JWT;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace IslamicFace.Infrastructure.Services.IdentityServices;
public class AppUserService(UserManager<AppUser> _userManager,JWT _jwt) : IAppUserService
{
    //this implementation will call from user operations handlers CORS

    public string? GetErrorDetails(IdentityResult result)
    {
        if (!result.Succeeded)
        {
            StringBuilder errors = new StringBuilder();
            foreach (var error in result.Errors)
            {
                errors.Append($"{error.Description},");
            }

            return errors.ToString();
        }
        return null;
    }
   
    public async Task<Result<RegisterCommandResponse>> RegisterCredentialAsync(RegisterCommand command)
    {
        if (await _userManager.FindByEmailAsync(command.Email) is not null)
            return Result.Failure<RegisterCommandResponse>(new Error("Validation error", "Email already registered", ErrorType.Validation));

        if (await _userManager.FindByNameAsync(command.UserName) is not null)
            return Result.Failure<RegisterCommandResponse>(new Error("Validation error", "UserName already registered", ErrorType.Validation));

        AppUser user = new()
        {
            UserName = command.UserName,
            Email = command.Email
        };

        string? createErrorDetails = GetErrorDetails(await _userManager.CreateAsync(user, command.Password));
        if (createErrorDetails is not null)
            return Result.Failure<RegisterCommandResponse>(new Error("Create Errors", createErrorDetails.TrimEnd(','), ErrorType.Conflict));

        string? addRoleErrorDetails = GetErrorDetails(await _userManager.AddToRoleAsync(user, "User"));
        if (addRoleErrorDetails is not null)
            return Result.Failure<RegisterCommandResponse>(new Error("Create Errors", addRoleErrorDetails.TrimEnd(','), ErrorType.Conflict));

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var encodedToken = WebUtility.UrlEncode(token);

        var confirmationLink = $"https://localhost:7145/confirm-email?userId={user.Id}&token={encodedToken}";

         //await _emailSender.SendEmailAsync(user.Email, "Confirm your email", confirmationLink);

        return Result.Success(new RegisterCommandResponse()
        {
            Id = user.Id,
            Token = null, 
            ConfirmationLink = confirmationLink
        });
    }

    public async Task<Result> ConfirmEmailAsync(Guid userId, string token)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        if (user == null)
            return Result.Failure(new Error("Not found", "User not found", ErrorType.NotFound));

        var decodedToken = WebUtility.UrlDecode(token);
        string? emailConfirmationErrorDetails = GetErrorDetails(await _userManager.ConfirmEmailAsync(user, decodedToken));

        if (emailConfirmationErrorDetails is not null)
            return Result.Failure(new Error("Create Errors", emailConfirmationErrorDetails.TrimEnd(','), ErrorType.Conflict));

        return Result.Success();
    }
    public Task<Result<AddReminderInfoForUserResponse>> AddReminderInfoForUserAsync(AddReminderInfoForUserCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<Result<LoginUserResponse>> LoginAsync(RegisterCommand command)
    {
        throw new NotImplementedException();
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
             new Claim(JwtRegisteredClaimNames.Email,appUser.UserName),
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

}
