using GymManagerApp.Domain.Entities;

namespace GymManagerApp.Application.Common.Interfaces
{
    public interface IJwtProvider
	{
		string Generate(User user);
	}
}
