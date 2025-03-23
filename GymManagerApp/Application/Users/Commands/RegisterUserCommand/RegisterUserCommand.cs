using GymManagerApp.Application.Common.Interfaces.CQRS;
using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Application.Users.Commands.RegisterUserCommand;

public sealed record RegisterUserCommand(string Name, string LastName, Gender Gender, string PhoneNumber, string Email, string Password, Role Role) : ICommand;