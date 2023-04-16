using EducationPlatform_GraduationProject.Data;
using EducationPlatform_GraduationProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EducationPlatform_GraduationProject.Controllers
{
	[Authorize(Roles = "Admin")]
	public class SecondController : Controller
	{

		readonly private ApplicationDbContext _context;

		public SecondController(ApplicationDbContext context)
		{
			_context = context;
		}
		//Api Url
		string Baseurl = "http://localhost:5295/";
		HttpClientHandler _clienthandler = new HttpClientHandler();
		ContentWithDetails details = new ContentWithDetails();

		public async Task<IActionResult> Index()
		{
			HttpClient client = new HttpClient();
			HttpResponseMessage response = await client.GetAsync($"{Baseurl}api/Contents/ContentByClassID/2");

			if (response.IsSuccessStatusCode)
			{
				string Res = await response.Content.ReadAsStringAsync();
				List<ContentVM>? contents = JsonConvert.DeserializeObject<List<ContentVM>>(Res);
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
