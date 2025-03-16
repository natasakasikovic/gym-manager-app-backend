using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Application.TrainingType.Queries.GetTrainingTypes
{
	public record TrainingTypeResponse(int Id, string Name, string Description, TrainingIntensity Intensity);
}
