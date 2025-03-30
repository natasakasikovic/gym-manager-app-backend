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
			return HandleFailure(response);

		return Ok(response.Value);
	}

	[HttpPost("registration")]
	public async Task<IActionResult> Register([FromBody] RegistrationRequest request)
	{
		var response = await Sender.Send(new RegisterUserCommand(request.Name, request.LastName, request.Gender, request.PhoneNumber, request.Email, request.Password, request.Role));

		if (response.IsFailure)
			return HandleFailure(response);

		return Ok(response.Value);
	}
}