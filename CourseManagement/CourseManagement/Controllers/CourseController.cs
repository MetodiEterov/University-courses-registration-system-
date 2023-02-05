using CourseManagement.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CourseManagement.Controllers
{
	public class CourseController : Controller
	{
		private readonly ILogger<CourseController> _logger;

		public CourseController(ILogger<CourseController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}