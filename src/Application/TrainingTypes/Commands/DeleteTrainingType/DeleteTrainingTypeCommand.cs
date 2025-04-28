﻿using Application.Common.Interfaces.CQRS;
using Application.Common.Interfaces.Repositories;
using Application.Common.Models;

namespace Application.TrainingTypes.Commands.DeleteTrainingType;

public sealed record DeleteTrainingTypeCommand(int Id) : ICommand { }

public class DeleteTrainingTypeCommandHandler : ICommandHandler<DeleteTrainingTypeCommand>
{
	private ITrainingTypeRepository _repository;

	public DeleteTrainingTypeCommandHandler(ITrainingTypeRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result> Handle(DeleteTrainingTypeCommand request, CancellationToken cancellationToken)
	{
		bool isSuccess = await _repository.Delete(request.Id);

		if (!isSuccess)
			return Result.Failure(Error.NullValue);

		return Result.Success();
	}
}