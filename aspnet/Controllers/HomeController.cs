using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspnet.Models;
using aspnet.Code;
using Microsoft.Extensions.Configuration;

namespace aspnet.Controllers
{
	[TypeFilter(typeof(TestActionFilter))]
	public class HomeController : Controller
	{
		//private IStringModifierService s1;
		//private IConfiguration _cfg;
		//public HomeController(IStringModifierService svc, IConfiguration cfg)
		//{
		//	s1 = svc;
		//	_cfg = cfg;
		//}		

		readonly IStringModifierService uppercaseService;
		readonly IStringModifierService reverserService;
		readonly IStringModifierService rereverserService;
		public HomeController(Func<ModifierEnum, IStringModifierService> resolver)
		{
			uppercaseService = resolver(ModifierEnum.Uppercase);
			reverserService = resolver(ModifierEnum.Reverser);
			rereverserService = resolver(ModifierEnum.ReReverser);
		}
		public IActionResult Index()
		{
			ViewData["Message"] = reverserService.Modify(uppercaseService.Modify("Application uses"));
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

#region notes
// [FromServices] UpperCaseService u
#endregion
