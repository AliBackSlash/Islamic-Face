namespace IslamicFace.Application.Features.AuthFeature.Commands.LoginCommand;

public record LoginCommand(string UserNameOrEmail, string? Password) : ICommand<LoginCommandResponse>;
