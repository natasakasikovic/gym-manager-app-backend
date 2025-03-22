using GymManagerApp.Domain.Common;
using GymManagerApp.Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;

namespace GymManagerApp.Infrastructure.Database.Repositories;

public abstract class GenericRepository<T> :IRepository<T> where T : BaseEntity
{

    private readonly DatabaseContext _dbContext;

    public GenericRepository(DatabaseContext dbContext)
    {
        _dbContext = dbContext;   
    }

    public async Task Add(T entity)
    {
        _dbContext.Set<T>().Add(entity);
		await _dbContext.SaveChangesAsync();
	}

	public async Task Update(T entity)
	{
		_dbContext.Set<T>().Update(entity);
		await _dbContext.SaveChangesAsync();
	}

	public async Task<bool> Delete(int id)
    {
        T entity = await Get(id);

        if (entity is null)
            return false;

        _dbContext.Set<T>().Remove(entity);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<T?> Get(int id)
    {
        return  _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);
    }

    public async Task<IEnumerable<T>> GetAll()
    {
        return await _dbContext.Set<T>().ToListAsync();
    }
	public IQueryable<T> GetAllQueryable()
	{
		return _dbContext.Set<T>().AsQueryable();
	}
}