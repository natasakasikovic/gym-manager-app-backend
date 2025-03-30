using GymManagerApp.Application.Common;
using GymManagerApp.Application.Common.Interfaces.CQRS;
using GymManagerApp.Domain.Entities;
using GymManagerApp.Domain.RepositoryInterfaces;

namespace GymManagerApp.Application.Trainings.Commands.AddParticipantToTraining;

public sealed record AddParticipantToTrainingCommand(int TrainingId, int ParticipantId) : ICommand; // TODO: get participant from token!

public class AddParticipantToTrainingCommandHandler : ICommandHandler<AddParticipantToTrainingCommand>
{
	private readonly ITrainingRepository _repository;
	private readonly IUserRepository _userRepository;

	public AddParticipantToTrainingCommandHandler(ITrainingRepository repository, IUserRepository userRepository)
	{
		_repository = repository;
		_userRepository = userRepository;
	}

	public async Task<Result> Handle(AddParticipantToTrainingCommand request, CancellationToken cancellationToken)
	{
		var training = await _repository.Get(request.TrainingId);

		if (training == null)
			return Result.Failure(Error.NullValue);

		if (training.IsFull())
			return Result.Failure(new Error("Error.TrainingIsFull", "The training session is already full."));

		var user = await _userRepository.Get(request.ParticipantId);


		if (user is not Member member)
			return Result.Failure(new Error("Error.InvalidUser", "The user is not a member of the gym."));

		if (training.IsAlreadyParticipant(member))
			return Result.Failure(new Error("Error.AlreadyRegistered", "You are already registered for this training session."));


		training.AddParticipant(member);

		await _repository.Update(training);

		return Result.Success();
	}
}
