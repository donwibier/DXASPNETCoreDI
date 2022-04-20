using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Code
{
	public enum ModifierEnum
    {
		Uppercase,
		Reverser,
		ReReverser
    }

	public interface IStringModifierService
	{
		string Modify(string input);
	}

	public class UpperCaseService : IStringModifierService
	{
		public string Modify(string input)
		{
			return input.ToUpperInvariant();
		}
	}

	public class ReverserService : IStringModifierService
	{
		//https://www.dotnetperls.com/reverse-string
		private string Reverse(string input)
		{
			char[] array = new char[input.Length];
			int forward = 0;
			for (int i = input.Length - 1; i >= 0; i--)
			{
				array[forward++] = input[i];
			}
			return new string(array);
		}
		public string Modify(string input)
		{
			return Reverse(input);
		}
	}

	public class ReReverserService : IStringModifierService
	{
		IStringModifierService _r;
		public ReReverserService(ReverserService r)
		{
			_r = r;
		}
		public string Modify(string input)
		{
			return _r.Modify(_r.Modify(input));
		}
	}

    public interface IUpperCaseService : IStringModifierService
    {

    }
    public interface ISomeotherService : IStringModifierService
    {

    }

}

#region notes



#endregion
