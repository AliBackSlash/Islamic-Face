using IslamicFace.Application.Features.AuthFeature.Commands;
using IslamicFace.Domain.JWT;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IslamicFace.Infrastructure.Services.IdentityServices;
public class AppUserService(UserManager<AppUser> _userManager,JWT _jwt) : IAppUserService
{
    //this implementation will call from user operations handlers CORS
    public async Task<Result<RegisterCommandResponse>> RegisterCredentialAsync(RegisterCommand command)
    {
        if (await _userManager.FindByEmailAsync(command.Email) is not null)
            return Result.Failure<RegisterCommandResponse>(new Error ("Validation error", "Email already registered", ErrorType.Validation));
      
        if (await _userManager.FindByNameAsync(command.UserName) is not null)
            return Result.Failure<RegisterCommandResponse>(new Error ("Validation error", "UserName already registered", ErrorType.Validation));

        AppUser user = new() 
        {
            UserName = command.UserName,
            Email = command.Email,
            PasswordHash = command.Password,
            
        };

        var CreateResult = await _userManager.CreateAsync(user,command.Password);

        if (!CreateResult.Succeeded)
        {
            StringBuilder errors = new StringBuilder();
            foreach (var error in CreateResult.Errors)
            {
                errors.Append($"{error.Description},");
            }

            return Result.Failure<RegisterCommandResponse>(new Error("Create Errors", errors.ToString().TrimEnd(','), ErrorType.Conflict));  
        }

        var AddToRoleResult = await _userManager.AddToRoleAsync(user, "User");//by default any registration operation by any user it's role will be "User"
                                                                              //** note i will move it tobe a trigger on table Users (AFTER INSERT)trigger

        if (!AddToRoleResult.Succeeded)
        {
            StringBuilder errors = new StringBuilder();
            foreach (var error in AddToRoleResult.Errors)
            {
                errors.Append($"{error.Description},");
            }

            return Result.Failure<RegisterCommandResponse>(new Error("Add to role Errors", errors.ToString().TrimEnd(','), ErrorType.Conflict));

        }

        var jwtSecurityToken = await CreateJWTToken(user);

        return Result.Success(new RegisterCommandResponse()
        {
            Id = user.Id,
            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
        });

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
            expires: DateTime.Now.AddMinutes(_jwt.Duration),
            signingCredentials: SigningCredentials
            );


    }

}
