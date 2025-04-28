using Application.Common.Interfaces;
using Application.Common.Interfaces.Security;
using Domain.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Security.Jwt;

public class JwtProvider : IJwtProvider
{

	private readonly JwtOptions _jwtOptions;
	private readonly IDateTime _dateTime;

	public JwtProvider(IOptions<JwtOptions> options, IDateTime dateTime)
	{
		_jwtOptions = options.Value;
		_dateTime = dateTime;
	}

	public string Generate(User user)
	{

		Claim[] claims = new Claim[]
		{
			new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
			new Claim(JwtRegisteredClaimNames.Email, user.Email),
			new Claim(ClaimTypes.Role, user.Role.ToString())
		};

		SigningCredentials signingCredentials = new SigningCredentials(
			new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey)),
			SecurityAlgorithms.HmacSha256);

		JwtSecurityToken token = new JwtSecurityToken(
			_jwtOptions.Issuer,
			_jwtOptions.Audience,
			claims,
			null,
			_dateTime.Now.AddMinutes(30),
			signingCredentials);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}
}
