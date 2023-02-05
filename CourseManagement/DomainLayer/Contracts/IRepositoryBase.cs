using System.Linq.Expressions;

namespace DomainLayer.Contracts
{
	public interface IRepositoryBase<T>
	{
		Task<IEnumerable<T>> GetAllAsync();

		Task<IEnumerable<T>> GetAllById(Expression<Func<T, bool>> predicate);

		Task<int> CreateAsync(T entity);

		Task<int> UpdateAsync(T entity);

		Task<int> DeleteAsync(T entity);

		Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate);
	}
}
