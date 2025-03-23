namespace GymManagerApp.Domain.Entities;

public class Member : User
{
    public DateTime MembershipExpiration { get; private set; }

    public void RenewMembership(DateTime newExpirationDate)
    {
        MembershipExpiration = newExpirationDate;
    }
}