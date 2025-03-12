using GymManagerApp.Domain.Entities.Common;
using GymManagerApp.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace GymManagerApp.Infrastructure.Database.Repositories
{
    public abstract class GenericRepository<T> :IRepository<T> where T : Entity
    {

        private readonly DatabaseContext _dbContext;

        public GenericRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;   
        }

        public async Task Add(T entity)
        {
            _dbContext.Set<T>().Add(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await Get(id);
            if (entity is not null)
                _dbContext.Set<T>().Remove(entity);
        }

        public async Task<T?> Get(int id)
        {
            return  _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

    }
}
