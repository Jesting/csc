using System;
namespace Lection8Program1
{
    [AttributeUsage(AttributeTargets.Method)]
    public class InvokeAfterCreationAttribute:Attribute
	{
		public string Value;
		public InvokeAfterCreationAttribute(string v)
		{
			Value = v;
		}
	}
}

