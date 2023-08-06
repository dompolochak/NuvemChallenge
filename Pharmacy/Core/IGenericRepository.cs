using System;
namespace Pharmacy.Core
{
	public interface IGenericRepository<T> where T: class
	{
		Task<IEnumerable<T>> All();
		Task<T?> GetByID(int id);
		Task<bool> Add(T entity);
		bool Update(T entity);
		Task<bool> Delete(T entity);
	}
}

