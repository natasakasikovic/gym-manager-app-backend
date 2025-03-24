using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Domain.Entities;

public class User : Person
{
    public string Email { get; protected set; }
    public string Password { get; protected set; }
    public Role Role { get; protected set; }

}