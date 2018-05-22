using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YouTubeBoardCore.Data;
using YouTubeBoardCore.Models;

namespace YouTubeBoardCore.Controllers
{
    public class VideoController : Controller
    {
	    private readonly UserManager<ApplicationUser> _userManager;
	    private readonly VideoDbContext _ctx;

		public VideoController(
			UserManager<ApplicationUser> userManager,
			VideoDbContext ctx)
		{
			_userManager = userManager;
			_ctx = ctx;
		}

		
        public IActionResult Index()
        {
			return View(_ctx.Videos.ToList());
		}

		[Authorize]
		[HttpGet]
	    public IActionResult Create()
		{
			return View();
		}
		
		[Authorize]
		[ValidateAntiForgeryToken]
		[HttpPost]
	    public async Task<IActionResult> Create([Bind("Id,Name,Description, Url")] VideoModel video)
	    {
		    if (ModelState.IsValid)
		    {
			    var user = await _userManager.GetUserAsync(User);

				video.Created = DateTime.Now;
			    video.UserEmail = user.Email;
			    video.UserName = user.UserName;
				
			    _ctx.Add(video);
			    await _ctx.SaveChangesAsync();
			    return RedirectToAction(nameof(Index));
		    }
		    return View(video);
		}
    }
}