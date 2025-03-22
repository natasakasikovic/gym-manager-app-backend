using GymManagerApp.Application.Common;
using GymManagerApp.Domain.Entities;
using GymManagerApp.Domain.RepositoryInterfaces;
using MediatR;

namespace GymManagerApp.Application.Trainings.Commands.UpdateTraining;

// TODO: consider adding more attributes
public sealed record UpdateTrainingCommand(int Id, DateTime ScheduledAt, int MaxParticipants) : IRequest<Result>;

public class UpdateTrainingCommandHandler : IRequestHandler<UpdateTrainingCommand, Result>
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