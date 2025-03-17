using GymManagerApp.Application.Common;
using MediatR;

namespace GymManagerApp.Application.TrainingTypes.Commands.DeleteTrainingType
{
	public sealed record DeleteTrainingTypeCommand(int Id) : IRequest<Result> { }
}
