using EducationPlatform_GraduationProject.Data;
using EducationPlatform_GraduationProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace EducationPlatform_GraduationProject.Controllers
{
	[Authorize(Roles ="Student")]
	public class StudentController : Controller
	{
		readonly private ApplicationDbContext _context;

		public StudentController(ApplicationDbContext context)
		{
			_context= context;
		}
		//Api Url
		string Baseurl = "http://localhost:5295/";
		HttpClientHandler _clienthandler = new HttpClientHandler();
		ContentWithDetails details = new ContentWithDetails();

		public async Task<IActionResult> Index()
		{
			var loggedUserName = User.Identity.Name;
			var loggedUserId = await _context.Students.Where(m => m.IdentityUser.Email == loggedUserName).Select(g => g.StId).FirstOrDefaultAsync();

			
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.GetAsync($"{Baseurl}api/Contents/StudentMonth/{loggedUserId}");
			
			if (response.IsSuccessStatusCode)
			{
				string Res = await response.Content.ReadAsStringAsync();
				List<ContentWithDetails>? contents = JsonConvert.DeserializeObject<List<ContentWithDetails>>(Res);
				return View(contents);

			}
			else
			{
				ViewBag.response = "Error";
			}
			return View();
			
		}
        public async Task<IActionResult> Details(int Id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{Baseurl}api/Contents/ContentByIDWithAllDetails/" + Id);
            if (response.IsSuccessStatusCode)
            {
                string Res = await response.Content.ReadAsStringAsync();
                ContentWithDetails contents = JsonConvert.DeserializeObject<ContentWithDetails>(Res);
                return View(contents);

            }
            else
            {
                return View("Error");
            }

        }
    }
}
