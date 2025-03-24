using GymManagerApp.Domain.Entities;

namespace GymManagerApp.Domain.RepositoryInterfaces;

public interface IUserRepository : IRepository<User> { 
	Task<User> GetByEmail(string email);
}