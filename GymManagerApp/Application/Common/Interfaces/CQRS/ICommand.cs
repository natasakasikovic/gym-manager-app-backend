using MediatR;

namespace GymManagerApp.Application.Common.Interfaces.CQRS;

public interface ICommand : IRequest<Result> { }

public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }
