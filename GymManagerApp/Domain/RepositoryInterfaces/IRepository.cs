using GymManagerApp.Domain.Entities.Common;

namespace GymManagerApp.Domain.RepositoryInterfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
            Task<IEnumerable<T>> GetAll();
            Task<T?> Get(int id);
            Task Add(T entity);
            Task Delete(int id);
    }
}