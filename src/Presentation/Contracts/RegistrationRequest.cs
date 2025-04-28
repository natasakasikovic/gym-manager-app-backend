using Domain.Enums;

namespace Presentation.Contracts;

public sealed record RegistrationRequest(string Name, string LastName, Gender Gender, string PhoneNumber, string Email, string Password, Role Role);