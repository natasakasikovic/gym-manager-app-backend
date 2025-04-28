using Application.Common.Interfaces;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Security;
using Infrastructure.Common;
using Infrastructure.Database;
using Infrastructure.Database.Repositories;
using Infrastructure.Security.CurrentUser;
using Infrastructure.Security.Jwt;
using Infrastructure.Security.Password;
using Microsoft.Extensions.Configuration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("DefaultConnection");
		services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));

		services.AddScoped<ITrainingRepository, TrainingRepository>();
		services.AddScoped<ITrainingTypeRepository, TrainingTypeRepository>();
		services.AddScoped<IUserRepository, UserRepository>();

		services.AddScoped<ICurrentUserProvider, CurrentUserProvider>();
		services.AddSingleton<IDateTime, DateTimeProvider>();
		services.AddTransient<IJwtProvider, JwtProvider>();
		services.AddTransient<ICryptographyProvider, CryptographyProvider>();

		services.ConfigureOptions<JwtOptionsSetup>();
		services.ConfigureOptions<JwtBearerOptionsSetup>();

		services.AddHttpContextAccessor();

		return services;
	}
}