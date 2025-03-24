using GymManagerApp.Application.Common.Interfaces;

namespace GymManagerApp.Infrastructure.Common;

public class CryptographyProvider : ICryptographyProvider
{
	public string HashPassword(string password)
	{
		byte[] data = System.Text.Encoding.ASCII.GetBytes(password);
		data = System.Security.Cryptography.SHA256.HashData(data);
		return System.Text.Encoding.ASCII.GetString(data);
	}
}