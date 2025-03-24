namespace GymManagerApp.Application.Users.Commands.LoginUserCommand;

public sealed record LoginResponse(string Email, string Jwt) { }