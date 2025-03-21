using GymManagerApp.Application.Common.Interfaces.CQRS;

namespace GymManagerApp.Application.TrainingTypes.Commands.DeleteTrainingType
{
    public sealed record DeleteTrainingTypeCommand(int Id) : ICommand { }
}