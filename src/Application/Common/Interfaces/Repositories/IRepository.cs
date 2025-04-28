﻿using Domain.Entities;

namespace Application.Common.Interfaces.Repositories;

public interface IRepository<T> where T : BaseEntity
{
	Task<IEnumerable<T>> GetAll();
	Task<T?> Get(int id);
	Task Add(T entity);
	Task Update(T entity);
	Task<bool> Delete(int id);
	IQueryable<T> GetAllQueryable();
}