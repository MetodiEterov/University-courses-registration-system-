using DomainLayer.Contracts;
using DomainLayer.Entities;

using System.Linq.Expressions;

namespace ServiceLayer.Services
{
	internal sealed class StudentCourseService : IStudentCourseService
	{
		private readonly IRepositoryManager _repositoryManager;
		public StudentCourseService(IRepositoryManager repositoryManager)
		{
			_repositoryManager = repositoryManager;
		}

		public async Task<int> CreateAsync(StudentCourse entity) => await _repositoryManager.StudentCourseRepository.CreateAsync(entity);

		public async Task<int> DeleteAsync(StudentCourse entity) => await _repositoryManager.StudentCourseRepository.DeleteAsync(entity);

		public async Task<bool> ExistsAsync(Expression<Func<StudentCourse, bool>> predicate) => await _repositoryManager.StudentCourseRepository.ExistsAsync(predicate);

		public async Task<IEnumerable<StudentCourse>> GetAllById(Expression<Func<StudentCourse, bool>> predicate) => await _repositoryManager.StudentCourseRepository.GetAllById(predicate);

		public async Task<IEnumerable<StudentCourse>> GetAll() => await _repositoryManager.StudentCourseRepository.GetAllAsync();

		public async Task<int> UpdateAsync(StudentCourse entity) => await _repositoryManager.StudentCourseRepository.UpdateAsync(entity);
	}
}
