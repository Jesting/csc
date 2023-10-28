using System;
namespace Lection16Program1
{
	public class BubbleSort
	{
		public void Sort(int[] arr)
		{
			if (arr == null)
				return;
			for (int i = 0; i < arr.Length-1; i++)
			{
				for (int j = 0; j < arr.Length - 1; j++)
				{
					if (arr[j] > arr[j + 1])
					{
						int t = arr[j];
						arr[j] = arr[j + 1];
						arr[j + 1] = t;
                    }
				}
			}
		}
	}
}

