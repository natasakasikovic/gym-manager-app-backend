using GymManagerApp.Application.Common.Interfaces.RepositoryInterfaces;
using GymManagerApp.Domain.Entities.User;

namespace GymManagerApp.Infrastructure.Database.Repositories
{
    public class AdminRepository : GenericRepository<Admin>, IAdminRepository
    {
        public AdminRepository(DatabaseContext dbContext) : base(dbContext) { }
    }
}
