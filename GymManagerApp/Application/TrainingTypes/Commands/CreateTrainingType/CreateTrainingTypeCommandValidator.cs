using FluentValidation;
using GymManagerApp.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace GymManagerApp.Application.TrainingTypes.Commands.CreateTrainingType;

public class CreateTrainingTypeCommandValidator : AbstractValidator<CreateTrainingTypeCommand>
{

	private readonly ITrainingTypeRepository _repository;

	public CreateTrainingTypeCommandValidator(ITrainingTypeRepository repository)
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

	private async Task<bool> BeUniqueTitle(string name, CancellationToken cancellationToken)
	{
		return !await _repository.GetAllQueryable().AnyAsync(t => t.Name == name, cancellationToken);
	}
}