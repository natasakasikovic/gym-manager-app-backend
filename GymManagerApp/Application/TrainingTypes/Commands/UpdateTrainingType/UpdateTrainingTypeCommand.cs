using GymManagerApp.Application.Common;
using GymManagerApp.Application.Common.Interfaces.CQRS;
using GymManagerApp.Domain.Entities;
using GymManagerApp.Domain.Enums;
using GymManagerApp.Domain.RepositoryInterfaces;

namespace GymManagerApp.Application.TrainingTypes.Commands.UpdateTrainingType
{
    public sealed record UpdateTrainingTypeCommand(int Id, string Name, string Description, TrainingIntensity Intensity) : ICommand<int> { }

	public class UpdateTrainingTypeCommandHandler : ICommandHandler<UpdateTrainingTypeCommand, int>
	{

		private readonly ITrainingTypeRepository _repository;

		public UpdateTrainingTypeCommandHandler(ITrainingTypeRepository repository)
		{
			_repository = repository;
		}

		public async Task<Result<int>> Handle(UpdateTrainingTypeCommand request, CancellationToken cancellationToken)
		{
			TrainingType type = await _repository.Get(request.Id);

			if (type is null)
				return Result.Failure<int>(Error.NullValue);

			type.Update(request.Name, request.Description, request.Intensity);
			await _repository.Update(type);

			return Result.Success(type.Id);
		}
	}
}