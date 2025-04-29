using Application.Common.Enums;
using Application.Common.Interfaces.CQRS;
using Application.Common.Interfaces.Repositories;
using Application.Common.Models;

namespace Application.TrainingTypes.Commands.DeleteTrainingType;

public sealed record DeleteTrainingTypeCommand(int Id) : ICommand { }

public class DeleteTrainingTypeCommandHandler : ICommandHandler<DeleteTrainingTypeCommand>
{
	private ITrainingTypeRepository _repository;
	private ITrainingRepository _trainingRepository;

	public DeleteTrainingTypeCommandHandler(ITrainingTypeRepository repository, ITrainingRepository trainingRepository)
	{
		_repository = repository;
		_trainingRepository = trainingRepository;
	}

	public async Task<Result> Handle(DeleteTrainingTypeCommand request, CancellationToken cancellationToken)
	{

		if (await _trainingRepository.ExistsByTrainingTypeIdAsync(request.Id))
			return Result.Failure(new Error("TrainingType.InUse", "Cannot delete training type because it is associated with existing trainings.", ErrorType.Conflict));
			
		bool isSuccess = await _repository.Delete(request.Id);

		if (!isSuccess)
			return Result.Failure(Error.NullValue);

		return Result.Success();
	}
}