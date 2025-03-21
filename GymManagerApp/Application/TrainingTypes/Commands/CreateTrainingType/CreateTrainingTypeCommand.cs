using GymManagerApp.Application.Common.Interfaces.CQRS;
using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Application.TrainingTypes.Commands.CreateTrainingType
{
    public sealed record CreateTrainingTypeCommand(string Name, string Description, TrainingIntensity Intensity) : ICommand { } 
}
