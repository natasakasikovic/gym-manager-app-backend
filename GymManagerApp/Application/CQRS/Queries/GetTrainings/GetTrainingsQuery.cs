using GymManagerApp.Application.DTOs;
using MediatR;

namespace GymManagerApp.Application.CQRS.Queries.GetTrainings
{
    public sealed record GetTrainingsQuery() : IRequest<List<TrainingDto>> { }
}