using MediatR;

namespace GymManagerApp.Application.Common.Interfaces.CQRS;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse> { }