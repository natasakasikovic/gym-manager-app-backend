using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Presentation.Contracts
{
	public sealed record UpdateTrainingTypeRequest(string Name, string Description, TrainingIntensity Intensity);
}
