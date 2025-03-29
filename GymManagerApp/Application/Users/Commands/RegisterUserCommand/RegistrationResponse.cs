using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Application.Users.Commands.RegisterUserCommand;
public sealed record RegistrationResponse(Role Role, string Jwt) { }