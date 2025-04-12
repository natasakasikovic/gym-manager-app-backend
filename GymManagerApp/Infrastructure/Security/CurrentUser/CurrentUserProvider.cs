using GymManagerApp.Application.Common.Interfaces.Security;
using System.Security.Claims;

namespace GymManagerApp.Infrastructure.Security;

public class CurrentUserProvider : ICurrentUserProvider
{

	private readonly IHttpContextAccessor _httpContextAccessor;

	public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
	{
		_httpContextAccessor = httpContextAccessor;
	}


	public int GetId()
	{
		var id = _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
		return int.Parse(id);
	}
}