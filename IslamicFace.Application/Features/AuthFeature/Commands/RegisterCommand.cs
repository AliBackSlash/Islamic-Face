namespace IslamicFace.Application.Features.AuthFeature.Commands;
public record RegisterCommand(string Email, string UserName, string Password) : ICommand<RegisterCommandResponse>;
