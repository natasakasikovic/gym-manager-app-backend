using GymManagerApp.Application.Common.Interfaces.RepositoryInterfaces;
using GymManagerApp.Domain.Entities.User;

namespace GymManagerApp.Infrastructure.Database.Repositories
{
    public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
    {
        public TrainerRepository(DatabaseContext dbContext) : base(dbContext)
        {
        }
    }
}
