using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Code
{
	public class TestActionFilter : ActionFilterAttribute
	{
		private readonly IStringModifierService _svc;
		public TestActionFilter(IStringModifierService svc)
		{
			_svc = svc;
		}

		public override void OnActionExecuting(ActionExecutingContext context)
		{
			Debug.WriteLine("OnActionExecuting");
		}
		public override void OnActionExecuted(ActionExecutedContext context)
		{
			Debug.WriteLine("OnActionExecuted");
		}
	}
}
