using GymManagerApp.Application.Common;
using GymManagerApp.Application.Common.Interfaces.CQRS;
using GymManagerApp.Application.Trainings.Queries.GetTrainings;
using MediatR;

namespace GymManagerApp.Application.CQRS.Queries.GetTrainings
{
    public sealed record GetUpcomingTrainingsQuery() : IQuery<List<TrainingResponse>> { }
}