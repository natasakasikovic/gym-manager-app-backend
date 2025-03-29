using GymManagerApp.Domain.Enums;
namespace GymManagerApp.Presentation.Contracts;

public sealed record RegistrationRequest(string Name, string LastName, Gender Gender, string PhoneNumber, string Email, string Password, Role Role);