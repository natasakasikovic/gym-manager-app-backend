using GymManagerApp.Application.Common;
using GymManagerApp.Application.Common.Interfaces.CQRS;
using GymManagerApp.Application.Common.Interfaces.RepositoryInterfaces;
using GymManagerApp.Domain.Entities;
using MediatR;
using System.Reflection.Metadata.Ecma335;

namespace GymManagerApp.Application.TrainingTypes.Commands.UpdateTrainingType
{
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
