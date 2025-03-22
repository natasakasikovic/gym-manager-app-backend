using GymManagerApp.Application.Common;
using GymManagerApp.Application.Common.Interfaces.CQRS;
using GymManagerApp.Domain.Entities.User;
using GymManagerApp.Domain.Entities;
using GymManagerApp.Domain.RepositoryInterfaces;
using MediatR;

namespace GymManagerApp.Application.Trainings.Commands.CreateTraining
{
    public sealed record CreateTrainingCommand(DateTime ScheduledAt, int TrainingTypeId, int TrainerId, int MaxParticipants) : ICommand { }

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
				return Result.Failure(Error.NullValue);

			Training training = Training.Create(type, request.ScheduledAt, trainer, request.MaxParticipants);
			await _repository.Add(training);

			return Result.Success();
		}
	}
}
