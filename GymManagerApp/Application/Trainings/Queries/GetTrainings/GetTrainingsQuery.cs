using GymManagerApp.Application.Common;
using GymManagerApp.Application.Common.CQRS;
using GymManagerApp.Application.Trainings.Queries.GetTrainings;
using MediatR;

namespace GymManagerApp.Application.CQRS.Queries.GetTrainings
{
    public sealed record GetTrainingsQuery() : IQuery<List<TrainingResponse>> { }
}