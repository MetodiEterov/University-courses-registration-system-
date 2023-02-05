using AutoMapper;

using DomainLayer.Contracts;
using DomainLayer.DTOs;
using DomainLayer.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace CourseManagement.Controllers
{
	public class AccountController : Controller
	{
		#region Constructor and initializations

		private readonly IMapper _mapper;
		private readonly IServiceManager _serviceManager;
		private readonly UserManager<User> _userManager;
		private readonly SignInManager<User> _signInManager;
		public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, IServiceManager serviceManager)
		{
			_mapper = mapper;
			_userManager = userManager;
			_signInManager = signInManager;
			_serviceManager = serviceManager;
		}

		#endregion

		#region GET methods

		[HttpGet]
		public IActionResult Register() => View();

		[HttpGet]
		public IActionResult Login(string returnUrl = null)
		{
			TempData["Errors"] = string.Empty;
			TempData["ReturnUrl"] = returnUrl;
			return View();
		}

		#endregion

		#region POST methods

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Login(StudentLogin userModel, string returnUrl = null)
		{
			if (!ModelState.IsValid) return ThrowErrors(null, "There model is not valid!");

			var result = await PasswordEmailSignInAsync(userModel);
			if (result.Succeeded)
				return RedirectToLocal(returnUrl);

			return ThrowErrors(null, "There is an issue with the user credentials!");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Logout()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(CourseController.Index), "Course");
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Register(StudentRegistration userModel)
        {
            if (ModelState.IsValid && !await _serviceManager.StudentService.ExistsAsync(x => x.StudentEmail == userModel.StudentEmail))
            {
                var newStudent = await AddNewStudent(userModel);
                if (newStudent != null)
                {
                    var result = await CreateNewUser(userModel, newStudent.Id);
                    if (!result.Succeeded)
                        return ThrowErrors(userModel, "There is an issue with the user!");
                }

                return RedirectToAction(nameof(CourseController.Index), "Course");
            }

            return ThrowErrors(userModel, "The model is not valid or the student exists!");
        }

        #endregion

        #region Private methods

        private async Task<Microsoft.AspNetCore.Identity.SignInResult> CreateNewUser(StudentRegistration userModel, Guid studentId)
        {
            User user = ConvertToUser(userModel, studentId);
            var result = await _userManager.CreateAsync(user, userModel.StudentPassword);
            if (!result.Succeeded)
                return Microsoft.AspNetCore.Identity.SignInResult.Failed;

            await _userManager.AddToRoleAsync(user, "RegularUser");
            return Microsoft.AspNetCore.Identity.SignInResult.Success;
        }

        private async Task<Microsoft.AspNetCore.Identity.SignInResult> PasswordEmailSignInAsync(StudentLogin userModel)
		{
			var user = await _userManager.FindByEmailAsync(userModel.StudentEmail);
			if (user == null)
				return Microsoft.AspNetCore.Identity.SignInResult.Failed;

			return await _signInManager.PasswordSignInAsync(user.StudentName, userModel.StudentPassword, false, false);
		}

		private async Task<Student> AddNewStudent(StudentRegistration userModel) => await _serviceManager.StudentService.CreateStudentAsync(_mapper.Map<Student>(userModel));

		private async Task<IEnumerable<Student>> GetAllStudents() => await _serviceManager.StudentService.GetAllStudents();

		private IActionResult ThrowErrors(StudentRegistration userModel, string errors)
		{
			TempData["Errors"] = HttpUtility.HtmlEncode(errors);
			return View(userModel);
		}

		private IActionResult RedirectToLocal(string returnUrl)
		{
			if (Url.IsLocalUrl(returnUrl))
				return Redirect(returnUrl);

			return RedirectToAction(nameof(CourseController.Index), "Course");
		}

        private User ConvertToUser(StudentRegistration userModel, Guid studentId)
        {
            User user = _mapper.Map<User>(userModel);
            user.StudentId = studentId.ToString();

            return user;
        }

        #endregion
    }
}
