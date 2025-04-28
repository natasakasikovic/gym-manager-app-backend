using Application.Common.Interfaces.Security;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Infrastructure.Security.CurrentUser;

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