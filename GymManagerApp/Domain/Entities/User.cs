using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Domain.Entities;

public abstract class User : Person
{
    public string Email { get; set; }
    public string Password { get; set; }
    public Role Role { get; set; }
}