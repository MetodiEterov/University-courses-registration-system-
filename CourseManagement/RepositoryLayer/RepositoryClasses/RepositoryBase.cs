using DomainLayer.Contracts;
using Microsoft.EntityFrameworkCore;
using RepositoryLayer.ApplicationContext;
using System.Linq.Expressions;

namespace RepositoryLayer.RepositoryClasses
{
	public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
	{
		protected readonly RepositoryContext _repositoryContext;
		public RepositoryBase(RepositoryContext repositoryContext)
		{
			_repositoryContext = repositoryContext;
		}

		public async Task<IEnumerable<T>> GetAllAsync() =>
			await _repositoryContext.Set<T>()?.AsNoTracking()?.ToListAsync() ?? null;

		public async Task<IEnumerable<T>> GetAllById(Expression<Func<T, bool>> predicate) =>
			await _repositoryContext.Set<T>().AsNoTracking().Where(predicate).ToListAsync();

		public async Task<int> CreateAsync(T entity)
		{
			await _repositoryContext.Set<T>().AddAsync(entity);
			return await SaveChangesSafeAsync();
		}

		public async Task<int> DeleteAsync(T entity)
		{
			_repositoryContext.Set<T>().Remove(entity);
			return await SaveChangesSafeAsync();
		}

		public async Task<int> UpdateAsync(T entity)
		{
			_repositoryContext.Entry(entity).State = EntityState.Modified;
			return await SaveChangesSafeAsync();
		}

		public virtual async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
			=> await _repositoryContext.Set<T>().AsNoTracking().AnyAsync(predicate);

		public async Task<int> SaveChangesSafeAsync()
		{
			try
			{
				return await _repositoryContext.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException ex)
			{
				foreach (var entry in ex.Entries)
				{
					var proposedValues = entry.CurrentValues;
					var databaseValues = entry.GetDatabaseValues();

					foreach (var property in proposedValues.Properties)
					{
						var proposedValue = proposedValues[property];
						var databaseValue = databaseValues[property];
					}

					entry.OriginalValues.SetValues(databaseValues);
				}

				return -1;
			}
		}
	}
}
