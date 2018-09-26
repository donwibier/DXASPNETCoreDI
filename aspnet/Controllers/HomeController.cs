using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnet.Models;
using aspnet.Code;

namespace aspnet.Controllers
{
	public class HomeController : Controller
	{
		public HomeController(IStringModifierService r, ReReverserService s)
		{
			_r = r;
			_s = s;
		}
		IStringModifierService _r;
		ReReverserService _s;

		public IActionResult Index([FromServices]UpperCaseService u)
		{
			ViewData["Message"] = u.Modify( _s.Modify("Application uses"));
			return View();
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

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
