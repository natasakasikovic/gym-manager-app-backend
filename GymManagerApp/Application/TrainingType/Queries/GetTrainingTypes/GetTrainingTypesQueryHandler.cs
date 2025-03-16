using GymManagerApp.Application.Common;
using GymManagerApp.Domain.RepositoryInterfaces;
using MediatR;

namespace GymManagerApp.Application.TrainingType.Queries.GetTrainingTypes
{
	public class GetTrainingTypesQueryHandler : IRequestHandler<GetTrainingTypesQuery, Result<List<TrainingTypeResponse>>>
	{

		private readonly ITrainingTypeRepository _repository;

        public GetTrainingTypesQueryHandler(ITrainingTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<List<TrainingTypeResponse>>> Handle(GetTrainingTypesQuery request, CancellationToken cancellationToken)
		{
			var types = await _repository.GetAll();

			List<TrainingTypeResponse> response = types.Select(t => new TrainingTypeResponse(t.Id, t.Name, t.Description, t.Intensity)).ToList(); // TODO: use AutoMapper?

			return Result.Success(response);
		}
	}
}
