using GymManagerApp.Application.Common.CQRS;
using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Application.TrainingTypes.Commands.UpdateTrainingType
{
	public sealed record UpdateTrainingTypeCommand(int Id, string Name, string Description, TrainingIntensity Intensity) : ICommand<int> { }
}