// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Threading.Tasks;
using EducationPlatform_GraduationProject.Data;
using EducationPlatform_GraduationProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EducationPlatform_GraduationProject.Areas.Identity.Pages.Account
{
	public class LogoutModel : PageModel
	{
		private readonly SignInManager<ApplicationUser> _signInManager;
		private readonly ILogger<LogoutModel> _logger;
		private readonly ApplicationDbContext _context;

		public LogoutModel(SignInManager<ApplicationUser> signInManager, ILogger<LogoutModel> logger, ApplicationDbContext context)
		{
			_signInManager = signInManager;
			_logger = logger;
			_context = context;
		}

		public async Task<IActionResult> OnPost(string returnUrl = null)
		{

			await _signInManager.SignOutAsync();
			var checkalogged = await _context.OneDeviceLogin.Where(m => m.userName == User.Identity.Name).FirstOrDefaultAsync();

			_context.OneDeviceLogin.Remove(checkalogged);
			await _context.SaveChangesAsync();
			_logger.LogInformation("User logged out.");
			if (returnUrl != null)
			{
				return LocalRedirect(returnUrl);
			}
			else
			{
				// This needs to be a redirect so that the browser performs a new
				// request and the identity for the user gets updated.
				return RedirectToPage();
			}
		}
	}
}
