using Domain.Entities;

namespace Application.Common.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
	Task<User> GetByEmail(string email);
}