using GymManagerApp.Application.Common.Interfaces.CQRS;

namespace GymManagerApp.Application.Users.Commands.LoginUserCommand;

public sealed record LoginUserCommand(string Email, string Password) : ICommand;