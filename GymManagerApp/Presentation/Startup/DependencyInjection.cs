using FluentValidation;
using GymManagerApp.Application.Common.Behaviours;
using GymManagerApp.Domain.RepositoryInterfaces;
using GymManagerApp.Infrastructure.Database.Repositories;
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

		return services;
	}

	private static IServiceCollection AddRepositories(this IServiceCollection services)
	{
		services.AddScoped<ITrainingRepository, TrainingRepository>();
		services.AddScoped<ITrainingTypeRepository, TrainingTypeRepository>();
		services.AddScoped<ITrainerRepository, TrainerRepository>();
		services.AddScoped<IAdminRepository, AdminRepository>();
		services.AddScoped<IMemberRepository, MemberRepository>();

		return services;
	}
}