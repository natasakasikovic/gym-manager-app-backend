using Application.Common.Interfaces.CQRS;
using Application.Common.Interfaces.Repositories;
using Application.Common.Models;
using Application.TrainingTypes.Queries.GetTrainingTypes;

namespace Application.TrainingTypes.Queries.GetTrainingType;

public sealed record GetTrainingTypeQuery(int Id) : IQuery<TrainingTypeResponse> { }

public class GetTrainingTypeQueryHandler : IQueryHandler<GetTrainingTypeQuery, TrainingTypeResponse>
{

	private readonly ITrainingTypeRepository _repository;

	public GetTrainingTypeQueryHandler(ITrainingTypeRepository repository)
	{
		_repository = repository;
	}

	public async Task<Result<TrainingTypeResponse>> Handle(GetTrainingTypeQuery request, CancellationToken cancellationToken)
	{
		var type = await _repository.Get(request.Id);

		if (type is null)
			return Result.Failure<TrainingTypeResponse>(Error.NullValue);

		var response = new TrainingTypeResponse(type.Id, type.Name, type.Description, type.Intensity);

		return Result.Success(response);
	}
}