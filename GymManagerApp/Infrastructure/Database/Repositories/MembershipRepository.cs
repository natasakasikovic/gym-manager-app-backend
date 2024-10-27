using GymManagerApp.Domain.Entities.User.Member;
using GymManagerApp.Domain.RepositoryInterfaces;

namespace GymManagerApp.Infrastructure.Database.Repositories
{
    public class MembershipRepository : GenericRepository<Membership>, IMembershipRepository
    {
        public MembershipRepository(DatabaseContext dbContext) : base(dbContext) { }
    }
}
