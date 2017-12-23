using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Util
{
	public static string UpperCamelCaseToWords(string uc)
	{
		return string.Join("", uc.ToCharArray().Select(c => (char.IsUpper(c) ? " " + c : c.ToString())).ToArray()).TrimStart();
	}
}