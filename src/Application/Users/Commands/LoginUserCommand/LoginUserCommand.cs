using Application.Common.Enums;
using Application.Common.Interfaces.CQRS;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Security;
using Application.Common.Models;
using Domain.Entities;

namespace Application.Users.Commands.LoginUserCommand;

public sealed record LoginUserCommand(string Email, string Password) : ICommand<LoginResponse>;

public class LoginUserCommandHandler : ICommandHandler<LoginUserCommand, LoginResponse>
{

	private readonly IUserRepository _repository;
	private readonly IJwtProvider _jwtProvider;
	private readonly ICryptographyProvider _cryptographyProvider;

	public LoginUserCommandHandler(IUserRepository repository, IJwtProvider jwtProvider, ICryptographyProvider cryptographyProvider)
	{
		_repository = repository;
		_jwtProvider = jwtProvider;
		_cryptographyProvider = cryptographyProvider;
	}

	public async Task<Result<LoginResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
	{
		User user = await _repository.GetByEmail(request.Email);

		if (user is null || !IsPasswordCorrect(user, request.Password))
			return Result.Failure<LoginResponse>(new Error("User.WrongCredentials", "Invalid user credentials", ErrorType.Unauthorized));

		string token = _jwtProvider.Generate(user);

		var response = new LoginResponse(user.Role, token);

		return Result.Success(response);
	}

	private bool IsPasswordCorrect(User user, string inputPassword)
	{
		string hashedPassword = _cryptographyProvider.HashPassword(inputPassword);
		return user.Password.Equals(hashedPassword);
	}
}