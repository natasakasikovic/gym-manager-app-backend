using GymManagerApp.Application.Common;
using GymManagerApp.Application.Common.Interfaces.RepositoryInterfaces;
using GymManagerApp.Domain.Entities;
using MediatR;

namespace GymManagerApp.Application.Trainings.Commands.UpdateTraining
{
    public class UpdateTrainingCommandHandler : IRequestHandler<UpdateTrainingCommand, Result>
	{
		private readonly ITrainingRepository _repository;

        public UpdateTrainingCommandHandler(ITrainingRepository repository)
        {
			_repository = repository;            
        }

        public async Task<Result> Handle(UpdateTrainingCommand request, CancellationToken cancellationToken)
		{
			Training training = await _repository.Get(request.Id);

			if (training is null)
				return Result.Failure<int>(Error.NullValue);

			training.Update(request.ScheduledAt, request.MaxParticipants);
			await _repository.Update(training);

			return Result.Success(training.Id);
		}
	}
}
