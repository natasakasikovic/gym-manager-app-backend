﻿using Application.Common.Interfaces.CQRS;
using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using Domain.Entities;
using Domain.Enums;

namespace Application.TrainingTypes.Commands.UpdateTrainingType;

public sealed record UpdateTrainingTypeCommand(int Id, string Name, string Description, TrainingIntensity Intensity) : ICommand { }

public class UpdateTrainingTypeCommandHandler : ICommandHandler<UpdateTrainingTypeCommand>
{

	private readonly ITrainingTypeRepository _repository;

	public UpdateTrainingTypeCommandHandler(ITrainingTypeRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result> Handle(UpdateTrainingTypeCommand request, CancellationToken cancellationToken)
	{
		TrainingType type = await _repository.Get(request.Id);

		if (type is null)
			return Result.Failure(Error.NullValue);

		type.Update(request.Name, request.Description, request.Intensity);
		await _repository.Update(type);

		return Result.Success();
	}
}