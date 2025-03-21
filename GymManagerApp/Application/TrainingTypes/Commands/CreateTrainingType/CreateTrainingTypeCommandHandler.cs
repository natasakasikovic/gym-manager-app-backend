using GymManagerApp.Application.Common;
using GymManagerApp.Application.Common.Interfaces.CQRS;
using GymManagerApp.Application.Common.Interfaces.RepositoryInterfaces;
using GymManagerApp.Domain.Entities;

namespace GymManagerApp.Application.TrainingTypes.Commands.CreateTrainingType
{
    public class CreateTrainingTypeCommandHandler : ICommandHandler<CreateTrainingTypeCommand>
	{

		private readonly ITrainingTypeRepository _repository;

        public CreateTrainingTypeCommandHandler(ITrainingTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result> Handle(CreateTrainingTypeCommand request, CancellationToken cancellationToken)
		{
			TrainingType type = TrainingType.Create(request.Name, request.Description, request.Intensity);

			await _repository.Add(type);

			return Result.Success();
		}
	}
}
