using GymManagerApp.Application.Common;
using GymManagerApp.Application.Common.CQRS;
using GymManagerApp.Domain.Entities.Training;
using GymManagerApp.Domain.Entities.User;
using GymManagerApp.Domain.RepositoryInterfaces;

namespace GymManagerApp.Application.Trainings.Commands.CreateTraining
{
	public class CreateTrainingCommandHandler : ICommandHandler<CreateTrainingCommand>
	{

		private readonly ITrainingRepository _repository;
		private readonly ITrainingTypeRepository _trainingTypeRepository;
		private readonly ITrainerRepository _trainerRepository;

        public CreateTrainingCommandHandler(ITrainingRepository repository, ITrainingTypeRepository trainingTypeRepository, ITrainerRepository trainerRepository)
        {
			_repository = repository;
			_trainingTypeRepository = trainingTypeRepository;
			_trainerRepository = trainerRepository;
        }

        public async Task<Result> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
		{
			TrainingType type = await _trainingTypeRepository.Get(request.TrainingTypeId);
			Trainer trainer = await _trainerRepository.Get(request.TrainerId);

			if (type == null || trainer == null)
				return Result.Faluire(Error.NullValue);

			Training training = Training.Create(type, request.ScheduledAt, trainer, request.MaxParticipants);
			await _repository.Add(training);

			return Result.Success();
		}
	}
}
