using GymManagerApp.Application.Common;
using GymManagerApp.Domain.Enums;
using MediatR;

namespace GymManagerApp.Application.TrainingTypes.Commands.UpdateTrainingType
{
	public sealed record UpdateTrainingTypeCommand(int Id, string Name, string Description, TrainingIntensity Intensity) : IRequest<Result<int>> { }
}