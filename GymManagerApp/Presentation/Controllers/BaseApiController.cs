using GymManagerApp.Application.Common;
using GymManagerApp.Application.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagerApp.Presentation.Controllers;


[ApiController]
public abstract class BaseApiController : ControllerBase
{

    protected readonly ISender Sender;

    protected BaseApiController(ISender sender) {
        Sender = sender;
    }

    protected IActionResult HandleFaluire(Result result) =>
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
            StatusCode(StatusCodes.Status401Unauthorized,new ProblemDetails
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

			_ => throw new ArgumentException("Unknown error type")
		};
}