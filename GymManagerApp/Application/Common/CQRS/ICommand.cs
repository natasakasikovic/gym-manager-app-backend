﻿using MediatR;

namespace GymManagerApp.Application.Common.CQRS
{
	public interface ICommand : IRequest<Result> { }

	public interface ICommand<TResponse> : IRequest<Result<TResponse>> { }
}
