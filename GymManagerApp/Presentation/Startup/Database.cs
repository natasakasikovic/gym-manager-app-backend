using GymManagerApp.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace GymManagerApp.Presentation.Startup;

public static class Database
{
	public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
	{
		var connectionString = configuration.GetConnectionString("DefaultConnection");
		services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));

		return services;
	}
}