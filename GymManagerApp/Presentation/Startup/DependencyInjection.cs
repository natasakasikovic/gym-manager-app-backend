using FluentValidation;
using GymManagerApp.Application.Common.Behaviours;
using GymManagerApp.Application.Common.Interfaces;
using GymManagerApp.Domain.RepositoryInterfaces;
using GymManagerApp.Infrastructure;
using GymManagerApp.Infrastructure.Database.Repositories;
using GymManagerApp.Infrastructure.Security;
using GymManagerApp.Infrastructure.Security.Jwt;
using GymManagerApp.Infrastructure.Security.Password;
using MediatR;
using System.Reflection;

namespace GymManagerApp.Presentation.Startup;

public static class DependencyInjection
{
	public static IServiceCollection AddApplicationServices(this IServiceCollection services)
	{
		services.AddRepositories();
		services.AddAutoMapper(typeof(Program).Assembly);
		services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehaviour<,>));
		services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehaviour<,>));
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
		services.AddSingleton<IDateTime, DateTimeProvider>();
		services.AddTransient<IJwtProvider, JwtProvider>();
		services.AddTransient<ICryptographyProvider, CryptographyProvider>();
		services.AddHttpContextAccessor();

		services.ConfigureOptions<JwtOptionsSetup>();
		services.ConfigureOptions<JwtBearerOptionsSetup>();

		return services;
	}

	private static IServiceCollection AddRepositories(this IServiceCollection services)
	{
		services.AddScoped<ITrainingRepository, TrainingRepository>();
		services.AddScoped<ITrainingTypeRepository, TrainingTypeRepository>();
		services.AddScoped<IUserRepository, UserRepository>();

		return services;
	}
}