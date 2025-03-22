using GymManagerApp.Application.Common;
using GymManagerApp.Application.Common.Interfaces;
using GymManagerApp.Application.Common.Interfaces.CQRS;
using GymManagerApp.Application.Trainings.Queries.GetTrainings;
using GymManagerApp.Domain.RepositoryInterfaces;

namespace GymManagerApp.Application.CQRS.Queries.GetTrainings;

public sealed record GetUpcomingTrainingsQuery() : IQuery<List<TrainingResponse>> { }

public class GetTrainingsQueryHandler : IQueryHandler<GetUpcomingTrainingsQuery, List<TrainingResponse>>
{

	private readonly ITrainingRepository _repository;
	private readonly IDateTime _dateTime;

	public GetTrainingsQueryHandler(ITrainingRepository repository, IDateTime dateTime)
	{
		_repository = repository;
		_dateTime = dateTime;
	}

	public async Task<Result<List<TrainingResponse>>> Handle(GetUpcomingTrainingsQuery request, CancellationToken cancellationToken)
	{
		var trainings = await _repository.GetAll();

		trainings = trainings.Where(t => t.IsUpcoming(_dateTime.Now)).ToList();

		List<TrainingResponse> response = trainings.Select(t => new TrainingResponse(t.Id, t.ScheduledAt, t.MaxParticipants)).ToList(); // TODO: use AutoMapper?

		return Result.Success(response);
	}
}