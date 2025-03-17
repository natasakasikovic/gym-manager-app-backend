using GymManagerApp.Application.Common;
using MediatR;

namespace GymManagerApp.Application.TrainingTypes.Queries.GetTrainingTypes
{
	public class GetTrainingTypesQuery : IRequest<Result<List<TrainingTypeResponse>>> {	}
}
