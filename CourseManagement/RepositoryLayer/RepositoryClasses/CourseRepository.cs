using DomainLayer.Contracts;
using DomainLayer.Entities;

using RepositoryLayer.ApplicationContext;

namespace RepositoryLayer.RepositoryClasses
{
	public class CourseRepository : RepositoryBase<Course>, ICourseRepository
	{
		private readonly RepositoryContext _repository;
		public CourseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
			_repository = repositoryContext;
		}
	}
}
