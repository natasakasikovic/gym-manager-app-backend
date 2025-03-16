using GymManagerApp.Application.Common;
using MediatR;

namespace GymManagerApp.Application.TrainingType.Queries.GetTrainingTypes
{
	public class GetTrainingTypesQuery : IRequest<Result<List<TrainingTypeResponse>>> {	}
}
