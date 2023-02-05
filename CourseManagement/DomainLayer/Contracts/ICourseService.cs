using DomainLayer.Entities;
using System.Linq.Expressions;

namespace DomainLayer.Contracts
{
	public interface ICourseService
	{
		Task<IEnumerable<Course>> GetAllCourses();

		Task<IEnumerable<Course>> GetAllById(Expression<Func<Course, bool>> predicate);

		Task<int> CreateAsync(Course entity);

		Task<int> UpdateAsync(Course entity);

		Task<int> DeleteAsync(Course entity);

		Task<bool> ExistsAsync(Expression<Func<Course, bool>> predicate);
	}
}
