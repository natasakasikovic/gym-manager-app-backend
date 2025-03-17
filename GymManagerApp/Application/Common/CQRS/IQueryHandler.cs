﻿using MediatR;

namespace GymManagerApp.Application.Common.CQRS
{
	public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse> { }
}