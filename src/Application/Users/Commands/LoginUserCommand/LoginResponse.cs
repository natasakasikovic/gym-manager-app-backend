using Domain.Enums;

namespace Application.Users.Commands.LoginUserCommand;

public sealed record LoginResponse(Role Role, string Jwt) { }