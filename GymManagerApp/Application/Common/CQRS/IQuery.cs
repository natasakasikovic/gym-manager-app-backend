using MediatR;

namespace GymManagerApp.Application.Common.CQRS
{
	public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
}
