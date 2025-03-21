using GymManagerApp.Application.Common.Interfaces.RepositoryInterfaces;
using GymManagerApp.Domain.Entities;

namespace GymManagerApp.Infrastructure.Database.Repositories
{
    public class TrainingTypeRepository : GenericRepository<TrainingType>, ITrainingTypeRepository
    {
        public TrainingTypeRepository(DatabaseContext dbContext) : base(dbContext) { }
    }
}
