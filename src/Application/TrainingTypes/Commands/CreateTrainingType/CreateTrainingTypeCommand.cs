using Application.Common.Interfaces.CQRS;
using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using Domain.Entities;
using Domain.Enums;

namespace Application.TrainingTypes.Commands.CreateTrainingType;

public sealed record CreateTrainingTypeCommand(string Name, string Description, TrainingIntensity Intensity) : ICommand { }

public class CreateTrainingTypeCommandHandler : ICommandHandler<CreateTrainingTypeCommand>
{

	private readonly ITrainingTypeRepository _repository;

	public CreateTrainingTypeCommandHandler(ITrainingTypeRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result> Handle(CreateTrainingTypeCommand request, CancellationToken cancellationToken)
	{
		TrainingType type = TrainingType.Create(request.Name, request.Description, request.Intensity);

		await _repository.Add(type);

		return Result.Success();
	}
}