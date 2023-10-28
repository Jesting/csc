using System;
namespace Lection7Program1
{
	public class BitsException:Exception
    {
		public BitsException(int bit):base($"Бит {bit} выходит за граниыцы диапазона 0..7")
		{	
		}
	}
}

