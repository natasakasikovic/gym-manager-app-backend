using GymManagerApp.Application.Common;
using GymManagerApp.Domain.Enums;
using MediatR;

namespace GymManagerApp.Application.TrainingTypes.Commands.CreateTrainingType
{
	public sealed record CreateTrainingTypeCommand(string Name, string Description, TrainingIntensity Intensity) : IRequest<Result> { } 
}
