using GymManagerApp.Application.DTOs;
using GymManagerApp.Domain.Entities.Training;
using GymManagerApp.Domain.RepositoryInterfaces;
using MediatR;

namespace GymManagerApp.Application.CQRS.Queries.GetTrainings
{
    public class GetTrainingsQueryHandler : IRequestHandler<GetTrainingsQuery, List<TrainingDto>>
    {

        private readonly ITrainingRepository _repository;

        public GetTrainingsQueryHandler(ITrainingRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TrainingDto>> Handle(GetTrainingsQuery request, CancellationToken cancellationToken)
        {
            List<Training> trainings = (await _repository.GetAll()).ToList();
			return trainings.Select(t => new TrainingDto(t.ScheduledAt, t.MaxParticipants)).ToList();
		}
	}
}
