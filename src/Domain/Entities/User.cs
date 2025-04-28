namespace Domain.Entities;

public class User : Person
{
	public string Email { get; protected set; }
	public string Password { get; protected set; }
	public Role Role { get; protected set; }


	protected User(string name, string lastName, Gender gender, string phoneNumber, string email, string password, Role role) : base(name, lastName, gender, phoneNumber)
	{

		Email = email;
		Password = password;
		Role = role;
	}

	public static User Create(string name, string lastName, Gender gender, string phoneNumber, string email, string password, Role role)
	{
		return new User(name, lastName, gender, phoneNumber, email, password, role);
	}
}