namespace DomainLayer.Contracts
{
	public interface IServiceManager
	{
		public IStudentService StudentService { get; }

		public ICourseService CourseService { get; }

		public IStudentCourseService StudentCourseService { get; }
	}
}
