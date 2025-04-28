using Application.Common.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Database.Repositories;

public class TrainingTypeRepository : GenericRepository<TrainingType>, ITrainingTypeRepository
{
	public TrainingTypeRepository(DatabaseContext dbContext) : base(dbContext) { }

	public async Task<bool> IsTrainingTypeNameUniqueAsync(string name, CancellationToken cancellationToken)
	{
		return !await _dbContext.TrainingTypes.AnyAsync(t => t.Name == name, cancellationToken);
	}

	public async Task<bool> IsTrainingTypeNameUniqueAsync(int id, string name, CancellationToken cancellationToken)
	{
		return !await _dbContext.TrainingTypes.Where(t => t.Id != id).AnyAsync(t => t.Name == name, cancellationToken);
	}
}