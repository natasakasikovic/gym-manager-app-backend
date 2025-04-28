using Domain.Entities;

namespace Application.Common.Interfaces.Security;

public interface IJwtProvider
{
	string Generate(User user);
}