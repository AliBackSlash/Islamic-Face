
namespace IslamicFace.Application.Features.AuthFeature.Commands;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Valid Email Is Required");
        RuleFor(x => x.UserName).NotEmpty().MinimumLength(6).MaximumLength(16).WithMessage("UserName must be between 6-16 characters");
        RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithMessage("Password must be greater than 8 characters");
    }
}
