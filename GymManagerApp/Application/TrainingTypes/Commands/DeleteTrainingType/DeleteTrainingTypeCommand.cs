using GymManagerApp.Application.Common.CQRS;

namespace GymManagerApp.Application.TrainingTypes.Commands.DeleteTrainingType
{
	public sealed record DeleteTrainingTypeCommand(int Id) : ICommand { }
}