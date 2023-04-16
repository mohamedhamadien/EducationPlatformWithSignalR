using Microsoft.AspNetCore.Mvc;

namespace EducationPlatform_GraduationProject.Controllers
{
	public class AdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
