using GymManagerApp.Domain.Entities;
using GymManagerApp.Domain.RepositoryInterfaces;

namespace GymManagerApp.Infrastructure.Database.Repositories;

public class TrainingRepository : GenericRepository<Training>, ITrainingRepository
{
    public TrainingRepository(DatabaseContext dbContext) : base(dbContext) { }
}