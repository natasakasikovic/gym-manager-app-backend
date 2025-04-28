using Application.Common.Interfaces.Repositories;
using Domain.Entities;

namespace Infrastructure.Database.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
	public UserRepository(DatabaseContext dbContext) : base(dbContext) { }

	public async Task<User> GetByEmail(string email)
	{
		return await GetAllQueryable().FirstOrDefaultAsync(u => u.Email == email);
	}
}