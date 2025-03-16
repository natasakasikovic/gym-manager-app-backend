using GymManagerApp.Application.Common;
using GymManagerApp.Application.DTOs;
using GymManagerApp.Domain.Entities.Training;
using GymManagerApp.Domain.RepositoryInterfaces;
using MediatR;

namespace GymManagerApp.Application.CQRS.Queries.GetTrainings
{
    public class GetTrainingsQueryHandler : IRequestHandler<GetTrainingsQuery, Result<List<TrainingDto>>>
    {

        private readonly ITrainingRepository _repository;

        public GetTrainingsQueryHandler(ITrainingRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<TrainingDto>>> Handle(GetTrainingsQuery request, CancellationToken cancellationToken)
        {
            var trainings = await _repository.GetAll();

            trainings = trainings.Where(t => t.IsUpcoming()).ToList();

            List<TrainingDto> response = trainings.Select(t => new TrainingDto(t.ScheduledAt, t.MaxParticipants)).ToList(); // TODO: use AutoMapper?

			return Result.Success(response);
		}
	}
}