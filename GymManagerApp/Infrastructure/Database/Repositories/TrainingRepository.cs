﻿using GymManagerApp.Domain.Entities;
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
			.Include(t => t.Participants) // TODO: Replace with Lazy Loading when upgrading to .NET 8 (since LazyLoadingProxies package is only available for .NET 8 or higher)
			.FirstOrDefaultAsync(t => t.Id == id);
	}

	public async Task<IEnumerable<Training>> GetAll()
	{
		return await _dbContext.Trainings.Include(t => t.Type)
			.Include(t => t.Trainer)
			.ToListAsync();
	}
}