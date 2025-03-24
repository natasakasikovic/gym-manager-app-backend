namespace GymManagerApp.Application.Common.Interfaces;
public interface ICryptographyProvider
{
	public string HashPassword(string password);
}