using GymManagerApp.Application.Common.CQRS;
using MediatR;

namespace GymManagerApp.Application.Trainings.Commands.CreateTraining
{
	public sealed record CreateTrainingCommand(DateTime ScheduledAt, int TrainingTypeId, int TrainerId, int MaxParticipants) : ICommand { }
}
