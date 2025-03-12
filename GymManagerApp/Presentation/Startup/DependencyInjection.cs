using GymManagerApp.Domain.RepositoryInterfaces;
using GymManagerApp.Infrastructure.Database.Repositories;

namespace GymManagerApp.Presentation.Startup
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddApplicationServices(this IServiceCollection services)
		{
			services.AddRepositories();
			services.AddAutoMapper(typeof(Program).Assembly);
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

			return services;
		}

		private static IServiceCollection AddRepositories(this IServiceCollection services)
		{
			services.AddScoped<ITrainingRepository, TrainingRepository>();
			services.AddScoped<ITrainingTypeRepository, TrainingTypeRepository>();
			services.AddScoped<ITrainerRepository, TrainerRepository>();
			services.AddScoped<IAdminRepository, AdminRepository>();
			services.AddScoped<IMemberRepository, MemberRepository>();
			services.AddScoped<IMembershipRepository, MembershipRepository>();

			return services;
		}
	}
}
