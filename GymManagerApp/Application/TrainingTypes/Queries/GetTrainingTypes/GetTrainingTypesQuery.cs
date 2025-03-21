using GymManagerApp.Application.Common.Interfaces.CQRS;

namespace GymManagerApp.Application.TrainingTypes.Queries.GetTrainingTypes
{
    public class GetTrainingTypesQuery : IQuery<List<TrainingTypeResponse>> {	}
}
