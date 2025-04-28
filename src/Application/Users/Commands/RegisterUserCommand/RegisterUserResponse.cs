using Domain.Enums;

namespace Application.Users.Commands.RegisterUserCommand;
public sealed record RegistrationResponse(Role Role, string Jwt) { }