using AutoMapper;

using DomainLayer.Contracts;
using DomainLayer.DTOs;
using DomainLayer.Entities;
using DomainLayer.Exceptions;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using System.Web;

namespace CourseManagement.Controllers
{
	[Authorize]
	public class CourseController : Controller
	{
		#region Constructor and inizializations

		private readonly IMapper _autoMapper;
		private readonly IServiceManager _serviceManager;
		private readonly ILogger<CourseController> _logger;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly UserManager<User> _userManager;

		public CourseController(ILogger<CourseController> logger, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor
			, IServiceManager serviceManager, IMapper mapper)
		{
			_logger = logger;
			_autoMapper = mapper;
			_userManager = userManager;
			_serviceManager = serviceManager;
			_httpContextAccessor = httpContextAccessor;
		}

		#endregion

		#region GET methods

		public IActionResult Index() => View();

		public IActionResult Create() => View();

		public IActionResult Register() => View();

		[HttpGet]
		public async Task<IActionResult> Courses()
		{
			IEnumerable<Course> courses = await GetCurrentCourses();
			return View(courses);
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}

		#endregion

		#region POST methods

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(CourseCreate course)
		{
			if (!ModelState.IsValid || string.IsNullOrEmpty(course.CourseName))
				return ThrowErrors("The model is not valid!");

			if (!await _serviceManager.CourseService.ExistsAsync(x => x.CourseName == course.CourseName))
				await _serviceManager.CourseService.CreateAsync(_autoMapper.Map<Course>(course));

			return RedirectToAction(nameof(CourseController.Courses), "Course");
		}

		[HttpPost]
		public async Task<IActionResult> Courses(CourseRegister course)
		{
			if (!ModelState.IsValid || course.CourseId == 0)
				return View();

			string studentId = await GetCurrentStudentId();
			switch (course.Operation)
			{
				case "Register":
					await RegisterStudentToCourse(course, studentId);
					break;
				case "Unregister":
					await UnregisterStudentFromCourse(course, studentId);
					break;
				case "Delete":
					await DeleteCourse(course);
					break;
				default:
					break;
			}

			return await ReturnCourses();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditStudentFromCourse(CourseEdit course)
		{
			if (!ModelState.IsValid || course.CourseId == 0 || string.IsNullOrEmpty(course.CourseName))
			{
				TempData["Errors"] = "The model is not valid!";
				return RedirectToAction(nameof(CourseController.Courses), "Course");
			}

			if (await _serviceManager.CourseService.ExistsAsync(x => x.Id == course.CourseId))
			{
				var edited = _autoMapper.Map<Course>(course);
				await _serviceManager.CourseService.UpdateAsync(edited);
			}

			return RedirectToAction(nameof(CourseController.Courses), "Course");
		}

		#endregion

		#region Private methods

		private async Task RegisterStudentToCourse(CourseRegister course, string studentId)
		{
			if (!await _serviceManager.StudentCourseService.ExistsAsync(x => x.CourseId == course.CourseId && x.StudentId == Guid.Parse(studentId)))
			{
				var registered = _autoMapper.Map<StudentCourse>(course);
				registered.StudentId = Guid.Parse(studentId);
				await _serviceManager.StudentCourseService.CreateAsync(registered);
			}
		}

		private async Task UnregisterStudentFromCourse(CourseRegister course, string studentId)
		{
			if (await _serviceManager.StudentCourseService.ExistsAsync(x => x.CourseId == course.CourseId && x.StudentId == Guid.Parse(studentId)))
			{
				var registered = _autoMapper.Map<StudentCourse>(course);
				registered.StudentId = Guid.Parse(studentId);
				await _serviceManager.StudentCourseService.DeleteAsync(registered);
			}
		}

		private async Task DeleteCourse(CourseRegister course)
		{
			if (await _serviceManager.CourseService.ExistsAsync(x => x.Id == course.CourseId))
			{
				var deleted = _autoMapper.Map<Course>(course);
				await _serviceManager.CourseService.DeleteAsync(deleted);
			}
		}

		private async Task<IActionResult> ReturnCourses() => View(await GetCurrentCourses());

		private async Task<IEnumerable<Course>> GetCurrentCourses()
		{
			var studentId = await GetCurrentStudentId();
			var courses = await _serviceManager.CourseService.GetAllCourses();
			var studentCourseById = await _serviceManager.StudentCourseService.GetAllById(x => x.StudentId == Guid.Parse(studentId));
			if (studentCourseById.Any())
				foreach (var item in studentCourseById)
					((List<Course>)courses).Find(p => p.Id == item.CourseId).IsRegistered = true;
			
			return courses;
		}

		private async Task<string> GetCurrentStudentId()
		{
			var current = await _userManager.GetUserAsync(HttpContext.User);
			return current.StudentId;
		}

		private IActionResult ThrowErrors(string errors)
		{
			TempData["Errors"] = HttpUtility.HtmlEncode(errors);
			return View();
		}

		#endregion
	}
}