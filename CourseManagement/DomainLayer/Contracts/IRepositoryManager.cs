namespace DomainLayer.Contracts
{
	public interface IRepositoryManager
	{
		IStudentRepository StudentRepository { get; }

		ICourseRepository CourseRepository { get; }

		IStudentCourseRepository StudentCourseRepository { get; }
	}
}
