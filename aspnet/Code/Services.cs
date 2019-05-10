using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Code
{
	public interface IStringModifierService
	{
		string Modify(string input);
	}
	public interface IUpperCaseService: IStringModifierService
	{

	}
	public interface ISomeotherService : IStringModifierService
	{

	}
	public class ReverserService : IStringModifierService
	{
		//private string data;
		private string Reverse(string input)
		{
			TextElementEnumerator enumerator =
				StringInfo.GetTextElementEnumerator(input);

			List<string> elements = new List<string>();
			while (enumerator.MoveNext())
				elements.Add(enumerator.GetTextElement());

			elements.Reverse();
			string reversed = string.Concat(elements);
			return reversed;
		}
		public string Modify(string input)
		{
			return Reverse(input);
		}
	}

	public class UpperCaseService : IUpperCaseService
	{
		public string Modify(string input)
		{
			return input.ToUpperInvariant();
		}
	}

	public class ReReverserService : ISomeotherService
	{
		IStringModifierService _r;
		public ReReverserService(IStringModifierService r)
		{
			_r = r;
		}
		public string Modify(string input)
		{
			return _r.Modify(_r.Modify(input));
		}
	}
}

#region notes



#endregion
