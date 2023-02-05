using DomainLayer.Entities;
using System.Linq.Expressions;

namespace DomainLayer.Contracts
{
	public interface IStudentCourseService
	{
		Task<IEnumerable<StudentCourse>> GetAll();

		Task<IEnumerable<StudentCourse>> GetAllById(Expression<Func<StudentCourse, bool>> predicate);

		Task<int> CreateAsync(StudentCourse entity);

		Task<int> UpdateAsync(StudentCourse entity);

		Task<int> DeleteAsync(StudentCourse entity);

		Task<bool> ExistsAsync(Expression<Func<StudentCourse, bool>> predicate);
	}
}
