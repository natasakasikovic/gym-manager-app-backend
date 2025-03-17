using GymManagerApp.Application.Common;
using MediatR;

namespace GymManagerApp.Application.Trainings.Commands.UpdateTraining
{
	// TODO: consider adding more attributes
	public sealed record UpdateTrainingCommand(int Id, DateTime ScheduledAt, int MaxParticipants) : IRequest<Result>;
}
