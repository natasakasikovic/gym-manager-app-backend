namespace GymManagerApp.Domain.Entities.User;

public class Member : User
{
    public DateTime MembershipExpiration { get; private set; }
}