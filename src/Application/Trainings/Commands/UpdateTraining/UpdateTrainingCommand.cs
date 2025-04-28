using Application.Common.Models;
using Application.Common.Interfaces.CQRS;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Trainings.Commands.UpdateTraining;

public sealed record UpdateTrainingCommand(int Id, DateTime ScheduledAt, int MaxParticipants) : ICommand;

public class UpdateTrainingCommandHandler : ICommandHandler<UpdateTrainingCommand>
{
	private readonly ITrainingRepository _repository;

	public UpdateTrainingCommandHandler(ITrainingRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result> Handle(UpdateTrainingCommand request, CancellationToken cancellationToken)
	{
		Training training = await _repository.Get(request.Id);

		if (training is null)
			return Result.Failure<int>(Error.NullValue);

		training.Update(request.ScheduledAt, request.MaxParticipants);
		await _repository.Update(training);

		return Result.Success(training.Id);
	}
}