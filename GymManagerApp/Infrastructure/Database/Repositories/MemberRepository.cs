using GymManagerApp.Domain.Entities.User;
using GymManagerApp.Domain.RepositoryInterfaces;

namespace GymManagerApp.Infrastructure.Database.Repositories
{
	public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(DatabaseContext dbContext) : base(dbContext) { }
    }
}
