using GymManagerApp.Application.Common;
using GymManagerApp.Application.Common.CQRS;
using GymManagerApp.Application.Trainings.Queries.GetTrainings;
using GymManagerApp.Domain.Entities.Training;
using GymManagerApp.Domain.RepositoryInterfaces;
using MediatR;

namespace GymManagerApp.Application.CQRS.Queries.GetTrainings
{
    public class GetTrainingsQueryHandler : IQueryHandler<GetUpcomingTrainingsQuery, List<TrainingResponse>>
    {

        private readonly ITrainingRepository _repository;

        public GetTrainingsQueryHandler(ITrainingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<TrainingResponse>>> Handle(GetUpcomingTrainingsQuery request, CancellationToken cancellationToken)
        {
            var trainings = await _repository.GetAll();

            trainings = trainings.Where(t => t.IsUpcoming()).ToList();

            List<TrainingResponse> response = trainings.Select(t => new TrainingResponse(t.Id, t.ScheduledAt, t.MaxParticipants)).ToList(); // TODO: use AutoMapper?

			return Result.Success(response);
		}
	}
}