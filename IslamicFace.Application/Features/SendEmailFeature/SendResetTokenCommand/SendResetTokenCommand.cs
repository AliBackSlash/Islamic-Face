namespace IslamicFace.Application.Features.SendEmailFeature.SendResetTokenCommand;

public record SendResetTokenCommand(string email) : ICommand;

