using GymManagerApp.Domain.Entities;
using GymManagerApp.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace GymManagerApp.Infrastructure.Database.Repositories;

public class TrainingRepository : GenericRepository<Training>, ITrainingRepository
{
	public TrainingRepository(DatabaseContext dbContext) : base(dbContext) { }

	public async Task<Training?> Get(int id)
	{
		return await _dbContext.Trainings.Include(t => t.Type)
			.Include(t => t.Trainer)
			.FirstOrDefaultAsync(t => t.Id == id);
	}
}