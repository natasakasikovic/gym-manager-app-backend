using GymManagerApp.Application.Common.CQRS;

namespace GymManagerApp.Application.TrainingTypes.Queries.GetTrainingTypes
{
	public class GetTrainingTypesQuery : IQuery<List<TrainingTypeResponse>> {	}
}
