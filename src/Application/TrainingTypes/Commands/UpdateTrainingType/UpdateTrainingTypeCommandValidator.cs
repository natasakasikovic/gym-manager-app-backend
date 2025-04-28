using Application.Common.Interfaces.Repositories;
using Application.TrainingTypes.Commands.UpdateTrainingType;

namespace GymManagerApp.Application.TrainingTypes.Commands.UpdateTrainingType;

public class UpdateTrainingTypeCommandValidator : AbstractValidator<UpdateTrainingTypeCommand>
{

	private readonly ITrainingTypeRepository _repository;

	public UpdateTrainingTypeCommandValidator(ITrainingTypeRepository repository)
	{
		_repository = repository;

		RuleFor(t => t.Name)
			.NotEmpty().WithMessage("Name of training type is mandatory!")
			.MaximumLength(50).WithMessage("Training type name cannot exceed 50 characters!")
			.MustAsync(BeUniqueTitle).WithMessage("Training type name must be unique!");

		RuleFor(t => t.Description)
			.NotEmpty().WithMessage("Description of training type is mandatory!")
			.MaximumLength(150).WithMessage("Description must not exceed 150 characters.");
	}

	private async Task<bool> BeUniqueTitle(UpdateTrainingTypeCommand model, string name, CancellationToken cancellationToken)
	{
		return await _repository.IsTrainingTypeNameUniqueAsync(model.Id, name, cancellationToken);
	}
}