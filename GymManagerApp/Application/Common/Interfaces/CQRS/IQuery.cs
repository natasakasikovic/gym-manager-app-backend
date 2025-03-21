using MediatR;

namespace GymManagerApp.Application.Common.Interfaces.CQRS
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
}
