using Application.Common.Interfaces.CQRS;
using Application.Common.Interfaces.Repositories;
using Application.Common.Models;

namespace Application.TrainingTypes.Queries.GetTrainingTypes;

public class GetTrainingTypesQuery : IQuery<List<TrainingTypeResponse>> { }

public class GetTrainingTypesQueryHandler : IQueryHandler<GetTrainingTypesQuery, List<TrainingTypeResponse>>
{

	private readonly ITrainingTypeRepository _repository;

	public GetTrainingTypesQueryHandler(ITrainingTypeRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<List<TrainingTypeResponse>>> Handle(GetTrainingTypesQuery request, CancellationToken cancellationToken)
	{
		var types = await _repository.GetAll();

		List<TrainingTypeResponse> response = types.Select(t => new TrainingTypeResponse(t.Id, t.Name, t.Description, t.Intensity)).ToList();

		return Result.Success(response);
	}
}