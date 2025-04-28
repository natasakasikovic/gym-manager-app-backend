using Application.Common.Enums;
using Application.Common.Interfaces;
using Application.Common.Interfaces.CQRS;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Security;
using Application.Common.Models;
using Domain.Entities;
using Domain.Enums;

namespace Application.Users.Commands.RegisterUserCommand;

public sealed record RegisterUserCommand(string Name, string LastName, Gender Gender, string PhoneNumber, string Email, string Password, Role Role) : ICommand<RegistrationResponse>;

public class RegisterUserCommandHandler : ICommandHandler<RegisterUserCommand, RegistrationResponse>
{

	private readonly IUserRepository _repository;
	private readonly ICryptographyProvider _cryptographyProvider;
	private readonly IJwtProvider _jwtProvider;
	private readonly IDateTime _dateTime;

	public RegisterUserCommandHandler(IUserRepository repository, ICryptographyProvider cryptographyProvider, IJwtProvider jwtProvider, IDateTime dateTime)
	{
		_repository = repository;
		_cryptographyProvider = cryptographyProvider;
		_jwtProvider = jwtProvider;
		_dateTime = dateTime;
	}

	public async Task<Result<RegistrationResponse>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
	{
		var user = await _repository.GetByEmail(request.Email);

		if (user != null)
			return Result.Failure<RegistrationResponse>(new Error("Error.EmailInUse", "This email is already in use!", ErrorType.Conflict));

		string password = _cryptographyProvider.HashPassword(request.Password);


		if (request.Role == Role.Member)
			user = Member.Create(request.Name, request.LastName, request.Gender, request.PhoneNumber, request.Email, password, request.Role, _dateTime.Now.AddDays(30));
		else
			user = User.Create(request.Name, request.LastName, request.Gender, request.PhoneNumber, request.Email, password, request.Role);


		await _repository.Add(user);

		string token = _jwtProvider.Generate(user);

		var response = new RegistrationResponse(user.Role, token);

		return Result.Success(response);
	}
}