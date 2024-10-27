using GymManagerApp.Domain.Entities.Training;
using GymManagerApp.Domain.RepositoryInterfaces;

namespace GymManagerApp.Infrastructure.Database.Repositories
{
    public class TrainingTypeRepository : GenericRepository<TrainingType>, ITrainingTypeRepository
    {
        public TrainingTypeRepository(DatabaseContext dbContext) : base(dbContext) { }
    }
}
