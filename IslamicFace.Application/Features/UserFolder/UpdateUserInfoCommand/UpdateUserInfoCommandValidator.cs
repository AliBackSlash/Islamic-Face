namespace IslamicFace.Application.Features.UserFolder.UpdateUserInfoCommand;

public class UpdateUserInfoCommandValidator : AbstractValidator<UpdateUserInfoCommand>
{
    public UpdateUserInfoCommandValidator()
    {
        RuleFor(x => x.fName)
            .NotEmpty().WithMessage("First Name is required.")
            .MinimumLength(2).WithMessage("Name must be at least 2 characters long.")
            .MaximumLength(50).WithMessage("Name cannot exceed 100 characters.");
       
        RuleFor(x => x.lName)
            .NotEmpty().WithMessage("Seconed Name is required.")
            .MinimumLength(2).WithMessage("Name must be at least 2 characters long.")
            .MaximumLength(50).WithMessage("Name cannot exceed 100 characters.");

        RuleFor(x => x.countryID)
            .GreaterThan((short)0).WithMessage("Country is required");

        RuleFor(x => x.cityID)
            .GreaterThan((short)0).WithMessage("City is required");

        RuleFor(x => x.dateOfBirth)
            .LessThan(DateOnly.FromDateTime(DateTime.Today)).WithMessage("Date of birth cannot be in the future.")
            .Must(d => d < DateOnly.FromDateTime(DateTime.Today.AddYears(-10)))
            .WithMessage("User must be at least 10 years old.");
        //on production only
        //RuleFor(x => x.profilePictureURL)
        //    .Must(url => string.IsNullOrEmpty(url) || Uri.IsWellFormedUriString(url, UriKind.Absolute))
        //    .WithMessage("Profile picture URL must be a valid absolute URL.");

        RuleFor(x => x.bio)
            .MaximumLength(160).WithMessage("Bio cannot exceed 500 characters.");

        RuleFor(x => x.PhoneNumber)
            .Matches(@"^\+\d{10,15}$")
            .When(x => !string.IsNullOrWhiteSpace(x.PhoneNumber))
            .WithMessage("Phone number must be in a valid format starting with an Arab country code followed by the number.");



        RuleFor(x => x.settingId)
            .InclusiveBetween((byte)1, (byte)3)
            .WithMessage("Setting must be between 1 and 3 choice.");
    }
}
