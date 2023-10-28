using System;
namespace Lection3Program1
{
	public interface IFamily
	{
        Person this[int index]
        {
            get;
        }
        int Count { get; }
    }
}

