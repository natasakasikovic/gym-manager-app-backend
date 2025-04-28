namespace Application.Trainings.Commands.CreateTraining;

public class CreateTrainingCommandValidator : AbstractValidator<CreateTrainingCommand>
{
	public CreateTrainingCommandValidator()
	{
		RuleFor(t => t.MaxParticipants)
			.NotEmpty().WithMessage("Max participants ares required.")
			.GreaterThanOrEqualTo(1).WithMessage("MaxParticipants must be at least 1.");

		RuleFor(t => t.ScheduledAt)
			.NotEmpty().WithMessage("Please provide a date and time for the training.")
			.GreaterThanOrEqualTo(_ => DateTime.UtcNow).WithMessage("The training date cannot be in the past.");
	}
}