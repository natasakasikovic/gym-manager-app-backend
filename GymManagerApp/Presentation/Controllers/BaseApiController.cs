using GymManagerApp.Application.Common;
using GymManagerApp.Application.Common.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace GymManagerApp.Presentation.Controllers
{
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
                BadRequest(
                    new ProblemDetails
                    {
                        Title = "Bad request",
                        Type = result.Error.Code,
                        Detail = result.Error.Description,
                        Status = StatusCodes.Status400BadRequest
                    })

                // TODO: handle more errors
            };
    }
}