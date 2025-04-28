namespace Application.Common.Interfaces.Security;

public interface ICryptographyProvider
{
	string HashPassword(string password);
}