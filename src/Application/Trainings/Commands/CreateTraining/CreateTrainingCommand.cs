using Application.Common.Models;
using Application.Common.Interfaces.CQRS;
using Application.Common.Interfaces.Security;
using Application.Common.Interfaces.Repositories;
using Domain.Entities;

namespace Application.Trainings.Commands.CreateTraining;

public sealed record CreateTrainingCommand(DateTime ScheduledAt, int TrainingTypeId, int MaxParticipants) : ICommand { }

public class CreateTrainingCommandHandler : ICommandHandler<CreateTrainingCommand>
{

	private readonly ITrainingRepository _repository;
	private readonly ITrainingTypeRepository _trainingTypeRepository;
	private readonly IUserRepository _userRepository;
	private readonly ICurrentUserProvider _currentUserProvider;

	public CreateTrainingCommandHandler(ITrainingRepository repository, ITrainingTypeRepository trainingTypeRepository, IUserRepository userRepository, ICurrentUserProvider currentUserProvider)
	{
		_repository = repository;
		_trainingTypeRepository = trainingTypeRepository;
		_userRepository = userRepository;
		_currentUserProvider = currentUserProvider;
	}

	public async Task<Result> Handle(CreateTrainingCommand request, CancellationToken cancellationToken)
	{
		TrainingType type = await _trainingTypeRepository.Get(request.TrainingTypeId);

		var trainerId = _currentUserProvider.GetId();

		User trainer = await _userRepository.Get(trainerId);

		if (type == null || trainer == null)
			return Result.Failure(Error.NullValue);

		Training training = Training.Create(type, request.ScheduledAt, trainer, request.MaxParticipants);

		await _repository.Add(training);

		return Result.Success();
	}
}