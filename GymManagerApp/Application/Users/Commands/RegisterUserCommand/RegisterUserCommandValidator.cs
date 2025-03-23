namespace GymManagerApp.Application.Users.Commands.RegisterUserCommand;

using FluentValidation;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MaximumLength(50).WithMessage("Name can have a maximum of 50 characters");

		RuleFor(x => x.LastName)
            .NotEmpty().WithMessage("Last name is required")
            .MaximumLength(50).WithMessage("Last name can have a maximum of 50 characters");

		RuleFor(x => x.Gender)
			.NotEmpty().WithMessage("Gender is required")
			.IsInEnum().WithMessage("Invalid gender value");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number is required")
                .Matches(@"^\+?[0-9]{7,15}$").WithMessage("Invalid phone number format");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Invalid email format");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long");

        RuleFor(x => x.Role)
			.NotEmpty().WithMessage("Role is required")
			.IsInEnum().WithMessage("Invalid role value");
    }
}