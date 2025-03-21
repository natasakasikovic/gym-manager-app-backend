using GymManagerApp.Domain.Entities;
using GymManagerApp.Domain.RepositoryInterfaces;

namespace GymManagerApp.Infrastructure.Database.Repositories
{
	public class TrainingTypeRepository : GenericRepository<TrainingType>, ITrainingTypeRepository
    {
        public TrainingTypeRepository(DatabaseContext dbContext) : base(dbContext) { }
    }
}
