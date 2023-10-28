using System;
namespace Lection3Program1
{
	public interface IParent
	{
		public bool GetChildren(out Person[] children);
		public void TakeCare();
	}
}

