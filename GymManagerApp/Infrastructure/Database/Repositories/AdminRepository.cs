using GymManagerApp.Domain.Entities.User;
using GymManagerApp.Domain.RepositoryInterfaces;

namespace GymManagerApp.Infrastructure.Database.Repositories;

public class AdminRepository : GenericRepository<Admin>, IAdminRepository
{
    public AdminRepository(DatabaseContext dbContext) : base(dbContext) { }
}