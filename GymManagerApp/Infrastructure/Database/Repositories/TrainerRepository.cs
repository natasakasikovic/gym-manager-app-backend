using GymManagerApp.Domain.Entities.User;
using GymManagerApp.Domain.RepositoryInterfaces;

namespace GymManagerApp.Infrastructure.Database.Repositories;

public class TrainerRepository : GenericRepository<Trainer>, ITrainerRepository
{
    public TrainerRepository(DatabaseContext dbContext) : base(dbContext) { }
}
