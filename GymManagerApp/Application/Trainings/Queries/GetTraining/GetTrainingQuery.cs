using GymManagerApp.Application.Common;
using GymManagerApp.Application.Common.Interfaces.CQRS;
using GymManagerApp.Application.Trainings.Queries.GetTrainings;
using GymManagerApp.Domain.RepositoryInterfaces;

namespace GymManagerApp.Application.Trainings.Queries.GetTraining;

public sealed record GetTrainingQuery(int Id) : IQuery<TrainingResponse>;

public class GetTrainingQueryHandler : IQueryHandler<GetTrainingQuery, TrainingResponse>
{

	private readonly ITrainingRepository _repository;

    public GetTrainingQueryHandler(ITrainingRepository repository)
    {
		_repository = repository;
    }

    public async Task<Result<TrainingResponse>> Handle(GetTrainingQuery request, CancellationToken cancellationToken)
	{
		var training = await _repository.Get(request.Id);

		if (training is null)
			return Result.Failure<TrainingResponse>(Error.NullValue);

		var response = new TrainingResponse(training.Id, training.Type.Name, training.ScheduledAt, training.MaxParticipants);

		return Result.Success(response);
	}
}
