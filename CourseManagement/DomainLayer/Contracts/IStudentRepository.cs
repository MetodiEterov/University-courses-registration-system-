using DomainLayer.Entities;

namespace DomainLayer.Contracts
{
	public interface IStudentRepository : IRepositoryBase<Student>
	{
		Task<Student> CreateStudentAsync(Student entity);

		Task<Student> GetStudentAsyncWithCourses(Guid id);
	}
}
