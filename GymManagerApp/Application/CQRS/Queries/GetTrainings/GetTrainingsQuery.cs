using GymManagerApp.Application.Common;
using GymManagerApp.Application.DTOs;
using MediatR;

namespace GymManagerApp.Application.CQRS.Queries.GetTrainings
{
    public sealed record GetTrainingsQuery() : IRequest<Result<List<TrainingDto>>> { }
}