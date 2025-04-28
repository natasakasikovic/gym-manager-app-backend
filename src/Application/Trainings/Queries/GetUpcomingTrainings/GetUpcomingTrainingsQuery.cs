using Application.Common.Interfaces;
using Application.Common.Interfaces.CQRS;
using Application.Common.Interfaces.Repositories;
using Application.Common.Models;

namespace Application.Trainings.Queries.GetUpcomingTrainings;

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

		List<TrainingResponse> response = trainings.Select(t => new TrainingResponse(t.Id, t.Type.Name, t.ScheduledAt, t.MaxParticipants)).ToList();

		return Result.Success(response);
	}
}