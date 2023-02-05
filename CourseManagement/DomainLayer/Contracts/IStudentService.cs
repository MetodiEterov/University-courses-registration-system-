using DomainLayer.Entities;
using System.Linq.Expressions;

namespace DomainLayer.Contracts
{
	public interface IStudentService
	{
		Task<IEnumerable<Student>> GetAllStudents();

		Task<IEnumerable<Student>> GetAllById(Expression<Func<Student, bool>> predicate);

		Task<Student> GetStudentAsyncWithCourses(Guid id);

		Task<Student> CreateStudentAsync(Student entity);

		Task<int> CreateAsync(Student entity);

		Task<int> UpdateAsync(Student entity);

		Task<int> DeleteAsync(Student entity);

		Task<bool> ExistsAsync(Expression<Func<Student, bool>> predicate);
	}
}
