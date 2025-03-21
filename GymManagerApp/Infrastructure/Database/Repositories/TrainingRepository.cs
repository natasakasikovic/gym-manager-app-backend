using GymManagerApp.Application.Common.Interfaces.RepositoryInterfaces;
using GymManagerApp.Domain.Entities;

namespace GymManagerApp.Infrastructure.Database.Repositories
{
    public class TrainingRepository : GenericRepository<Training>, ITrainingRepository
    {
        public TrainingRepository(DatabaseContext dbContext) : base(dbContext) { }
    }
}
