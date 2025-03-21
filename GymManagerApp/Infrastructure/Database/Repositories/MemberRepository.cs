using GymManagerApp.Application.Common.Interfaces.RepositoryInterfaces;
using GymManagerApp.Domain.Entities.User;

namespace GymManagerApp.Infrastructure.Database.Repositories
{
    public class MemberRepository : GenericRepository<Member>, IMemberRepository
    {
        public MemberRepository(DatabaseContext dbContext) : base(dbContext) { }
    }
}
