using DomainLayer.Contracts;
using DomainLayer.Entities;

using Microsoft.EntityFrameworkCore;
using RepositoryLayer.ApplicationContext;

namespace RepositoryLayer.RepositoryClasses
{
	public class StudentRepository : RepositoryBase<Student>, IStudentRepository
	{
		private readonly DbSet<Student> _student;
		private readonly RepositoryContext _repository;
		public StudentRepository(RepositoryContext repositoryContext) : base(repositoryContext)
		{
			_student = repositoryContext.Set<Student>();
			_repository = repositoryContext;
		}

		public async Task<Student> CreateStudentAsync(Student entity)
		{
			var newStudent = await _repository.Set<Student>().AddAsync(entity);
			await SaveChangesSafeAsync();
			return newStudent.Entity;
		}

		public async Task<Student> GetStudentAsyncWithCourses(Guid id) => await _student
				.Include(x => x.Courses)
				.FirstOrDefaultAsync(x => x.Id == id);
	}
}
