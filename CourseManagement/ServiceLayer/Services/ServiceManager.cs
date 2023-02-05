using DomainLayer.Contracts;

namespace ServiceLayer.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IStudentService> _lazyStudentService;
        private readonly Lazy<ICourseService> _lazyCourseService;
        private readonly Lazy<IStudentCourseService> _lazyStudentCourseService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyStudentService = new Lazy<IStudentService>(() => new StudentService(repositoryManager));
            _lazyCourseService = new Lazy<ICourseService>(() => new CourseService(repositoryManager));
            _lazyStudentCourseService = new Lazy<IStudentCourseService>(() => new StudentCourseService(repositoryManager));
        }

        public IStudentService StudentService => _lazyStudentService.Value;

        public ICourseService CourseService => _lazyCourseService.Value;

        public IStudentCourseService StudentCourseService => _lazyStudentCourseService.Value;
    }
}
