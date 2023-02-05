using DomainLayer.Contracts;
using DomainLayer.Entities;

using System.Linq.Expressions;

namespace ServiceLayer.Services
{
	internal sealed class CourseService : ICourseService
	{
		private readonly IRepositoryManager _repositoryManager;
		public CourseService(IRepositoryManager repositoryManager)
		{
			_repositoryManager = repositoryManager;
		}

		public async Task<int> CreateAsync(Course entity) => await _repositoryManager.CourseRepository.CreateAsync(entity);

		public async Task<int> DeleteAsync(Course entity) => await _repositoryManager.CourseRepository.DeleteAsync(entity);

		public async Task<bool> ExistsAsync(Expression<Func<Course, bool>> predicate) => await _repositoryManager.CourseRepository.ExistsAsync(predicate);

        public async Task<IEnumerable<Course>> GetAllById(Expression<Func<Course, bool>> predicate) => await _repositoryManager.CourseRepository.GetAllById(predicate);

		public async Task<IEnumerable<Course>> GetAllCourses() => await _repositoryManager.CourseRepository.GetAllAsync();

		public async Task<int> UpdateAsync(Course entity) => await _repositoryManager.CourseRepository.UpdateAsync(entity);
	}
}
