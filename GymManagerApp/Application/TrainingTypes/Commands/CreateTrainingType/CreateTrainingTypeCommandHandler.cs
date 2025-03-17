using GymManagerApp.Application.Common;
using GymManagerApp.Domain.Entities.Training;
using GymManagerApp.Domain.RepositoryInterfaces;
using MediatR;

namespace GymManagerApp.Application.TrainingTypes.Commands.CreateTrainingType
{
	public class CreateTrainingTypeCommandHandler : IRequestHandler<CreateTrainingTypeCommand, Result>
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
