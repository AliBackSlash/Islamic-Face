namespace IslamicFace.Application.Features.SendEmailFeature.EmailConfirmationTokenCommand;

public record EmailConfirmationTokenCommand(string email) : ICommand;

