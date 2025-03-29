using GymManagerApp.Domain.Enums;

namespace GymManagerApp.Domain.Entities;

public class Member : User
{
	public DateTime MembershipExpiration { get; private set; }

	private Member(string name, string lastName, Gender gender, string phoneNumber, string email, string password, Role role, DateTime membershipExpiration)
	  : base(name, lastName, gender, phoneNumber, email, password, role)
	{
		MembershipExpiration = membershipExpiration;
	}

	public static Member Create(string name, string lastName, Gender gender, string phoneNumber, string email, string password, Role role, DateTime membershipExpiration)
	{
		return new Member(name, lastName, gender, phoneNumber, email, password, role, membershipExpiration);
	}

	public void RenewMembership(DateTime newExpirationDate)
	{
		MembershipExpiration = newExpirationDate;
	}
}