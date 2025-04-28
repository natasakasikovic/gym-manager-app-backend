namespace Domain.Entities;

public class Person : BaseEntity
{
	public string Name { get; protected set; }
	public string LastName { get; protected set; }
	public Gender Gender { get; protected set; }
	public string PhoneNumber { get; protected set; }

	protected Person(string name, string lastName, Gender gender, string phoneNumber)
	{
		Name = name;
		LastName = lastName;
		Gender = gender;
		PhoneNumber = phoneNumber;
	}
}