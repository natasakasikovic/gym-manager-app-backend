using GymManagerApp.Application.Common;
using GymManagerApp.Domain.RepositoryInterfaces;
using MediatR;

namespace GymManagerApp.Application.TrainingTypes.Commands.DeleteTrainingType
{
	public class DeleteTrainingTypeCommandHandler : IRequestHandler<DeleteTrainingTypeCommand, Result>
	{
		private ITrainingTypeRepository _repository;

        public DeleteTrainingTypeCommandHandler(ITrainingTypeRepository repository)
        {
			_repository = repository;            
        }

        public async Task<Result> Handle(DeleteTrainingTypeCommand request, CancellationToken cancellationToken)
		{
			var type = await _repository.Get(request.Id);

			if (type is null)
				return Result.Failure<Error>(Error.NullValue);

			await _repository.Delete(request.Id);

			return Result.Success();
		}
	}
}
