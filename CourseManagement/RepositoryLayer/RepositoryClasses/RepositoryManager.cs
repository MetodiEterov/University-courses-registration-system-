using DomainLayer.Contracts;
using RepositoryLayer.ApplicationContext;

namespace RepositoryLayer.RepositoryClasses
{
	public class RepositoryManager : IRepositoryManager
	{
		private readonly Lazy<IStudentRepository> _lazyStudentRepository;
		private readonly Lazy<ICourseRepository> _lazyCourseRepository;
		private readonly Lazy<IStudentCourseRepository> _lazyStudentCourseRepository;
		public RepositoryManager(RepositoryContext repositoryContext)
		{
			_lazyStudentRepository = new Lazy<IStudentRepository>(() => new StudentRepository(repositoryContext));
			_lazyCourseRepository = new Lazy<ICourseRepository>(() => new CourseRepository(repositoryContext));
			_lazyStudentCourseRepository = new Lazy<IStudentCourseRepository>(() => new StudentCourseRepository(repositoryContext));
		}

		public IStudentRepository StudentRepository => _lazyStudentRepository.Value;

		public ICourseRepository CourseRepository => _lazyCourseRepository.Value;

		public IStudentCourseRepository StudentCourseRepository => _lazyStudentCourseRepository.Value;
	}
}
