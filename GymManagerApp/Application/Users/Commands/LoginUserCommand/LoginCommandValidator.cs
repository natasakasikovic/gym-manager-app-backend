using FluentValidation;

namespace GymManagerApp.Application.Users.Commands.LoginUserCommand;

public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
{
	public LoginUserCommandValidator()
	{
		RuleFor(u => u.Email)
			.NotEmpty().WithMessage("Email is required");

		RuleFor(u => u.Password)
			.NotEmpty().WithMessage("Password is required");
	}
}