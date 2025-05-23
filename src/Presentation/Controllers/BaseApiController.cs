﻿using Application.Common.Enums;
using Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
public abstract class BaseApiController : ControllerBase
{

	protected readonly ISender Sender;

	protected BaseApiController(ISender sender)
	{
		Sender = sender;
	}

	protected IActionResult HandleFailure(Result result) =>
		result switch
		{
			{ IsSuccess: true } => throw new InvalidOperationException(),

			{ Error: { ErrorType: ErrorType.BadRequest } } =>
			BadRequest(new ProblemDetails
			{
				Title = "Bad request",
				Type = result.Error.Code,
				Detail = result.Error.Description,
				Status = StatusCodes.Status400BadRequest
			}),

			{ Error: { ErrorType: ErrorType.Unauthorized } } =>
			StatusCode(StatusCodes.Status401Unauthorized, new ProblemDetails
			{
				Title = "Unauthorized",
				Type = result.Error.Code,
				Detail = result.Error.Description,
				Status = StatusCodes.Status401Unauthorized
			}),

			{ Error: { ErrorType: ErrorType.Forbidden } } =>
			StatusCode(StatusCodes.Status403Forbidden, new ProblemDetails
			{
				Title = "Forbidden",
				Type = result.Error.Code,
				Detail = result.Error.Description,
				Status = StatusCodes.Status403Forbidden
			}),

			{ Error: { ErrorType: ErrorType.Conflict } } =>
			StatusCode(StatusCodes.Status409Conflict, new ProblemDetails
			{
				Title = "Conflict",
				Type = result.Error.Code,
				Detail = result.Error.Description,
				Status = StatusCodes.Status409Conflict
			}),

			_ => throw new ArgumentException("Unknown error type")
		};
}