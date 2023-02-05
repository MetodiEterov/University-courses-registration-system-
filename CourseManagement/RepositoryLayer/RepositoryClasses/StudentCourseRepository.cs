using DomainLayer.Contracts;
using DomainLayer.DTOs;
using DomainLayer.Entities;

using RepositoryLayer.ApplicationContext;

namespace RepositoryLayer.RepositoryClasses
{
	public class StudentCourseRepository : RepositoryBase<StudentCourse>, IStudentCourseRepository
	{
		private readonly RepositoryContext _repository;
		public StudentCourseRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
			_repository = repositoryContext;
		}
	}
}
