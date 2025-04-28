using Application.Common.Models;

namespace Application.Common.Interfaces.CQRS;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse> { }