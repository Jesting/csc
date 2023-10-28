using System;
namespace Lection3Program2
{
	public static class StringUtils
	{
		public static string Reverse(this string s)
		{
			return new String(s.ToCharArray().Reverse().ToArray());
		}
	}
}

