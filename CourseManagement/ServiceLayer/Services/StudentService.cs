using DomainLayer.Contracts;
using DomainLayer.Entities;

using System.Linq.Expressions;

namespace ServiceLayer.Services
{
	internal sealed class StudentService : IStudentService
	{
		private readonly IRepositoryManager _repositoryManager;

		public StudentService(IRepositoryManager repositoryManager)
		{
			_repositoryManager = repositoryManager;
		}

		public async Task<IEnumerable<Student>> GetAllById(Expression<Func<Student, bool>> predicate) => await _repositoryManager.StudentRepository.GetAllById(predicate);

		public async Task<IEnumerable<Student>> GetAllStudents() => await _repositoryManager.StudentRepository.GetAllAsync();

		public async Task<Student> GetStudentAsyncWithCourses(Guid id) => await _repositoryManager.StudentRepository.GetStudentAsyncWithCourses(id);

		public async Task<int> CreateAsync(Student entity) => await _repositoryManager.StudentRepository.CreateAsync(entity);

		public async Task<Student> CreateStudentAsync(Student entity) => await _repositoryManager.StudentRepository.CreateStudentAsync(entity);

		public async Task<int> DeleteAsync(Student entity) => await _repositoryManager.StudentRepository.DeleteAsync(entity);

		public async Task<bool> ExistsAsync(Expression<Func<Student, bool>> predicate) => await _repositoryManager.StudentRepository.ExistsAsync(predicate);

		public async Task<int> UpdateAsync(Student entity) => await _repositoryManager.StudentRepository.UpdateAsync(entity);
	}
}
