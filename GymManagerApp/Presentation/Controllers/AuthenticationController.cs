using GymManagerApp.Application.Users.Commands.LoginUserCommand;
using GymManagerApp.Application.Users.Commands.RegisterUserCommand;
using GymManagerApp.Presentation.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GymManagerApp.Presentation.Controllers;

[Route("api/auth")]
public class AuthenticationController : BaseApiController
{
    public AuthenticationController(ISender sender) : base(sender) { }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var response = await Sender.Send(new LoginUserCommand(request.Email, request.Password));

		if (response.IsFailure)
			return HandleFaluire(response);

		return Ok(response.Value);
	}

}