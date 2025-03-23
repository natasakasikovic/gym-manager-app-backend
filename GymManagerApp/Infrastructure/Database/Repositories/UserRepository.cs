using GymManagerApp.Domain.Entities;
using GymManagerApp.Domain.RepositoryInterfaces;

namespace GymManagerApp.Infrastructure.Database.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(DatabaseContext dbContext) : base(dbContext) { }
}