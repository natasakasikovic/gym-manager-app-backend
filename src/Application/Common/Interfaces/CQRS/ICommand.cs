using Application.Common.Models;

namespace Application.Common.Interfaces.CQRS;

public interface ICommand : IRequest<Result> { }

public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }