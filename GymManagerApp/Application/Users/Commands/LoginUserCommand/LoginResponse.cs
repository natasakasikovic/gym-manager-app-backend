using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Application.Users.Commands.LoginUserCommand;

public sealed record LoginResponse(Role Role, string Jwt) { }