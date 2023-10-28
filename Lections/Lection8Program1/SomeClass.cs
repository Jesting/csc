using System;
namespace Lection8Program1
{
    public class SomeClass
	{
		public SomeClass()
		{
		}

		[InvokeAfterCreation("Я вызван с помощью рефлексии.")]
		private void SpecialMethod(string msg)
		{
			Console.WriteLine(msg);
		}
	}
}

