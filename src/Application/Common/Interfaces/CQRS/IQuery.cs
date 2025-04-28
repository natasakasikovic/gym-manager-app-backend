using Application.Common.Models;

namespace Application.Common.Interfaces.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }