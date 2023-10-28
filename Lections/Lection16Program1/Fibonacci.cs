using System;
namespace Lection16Program1
{
	public class Fibonacci
	{
		public int Calculate(int number)
		{
			if (number < 1)
				throw new ArgumentOutOfRangeException("Fibonacci number can't be less then 1");

            if (number > 46)
                throw new ArgumentOutOfRangeException("Fibonacci exceed maximum integer value");

            int first = 1, second = 1;

			for (int i = 2; i <= number; i++)
			{
				int temp = first;
				first = second;
				second = first + temp;
			}

			return first;
        }


        public int CalculateRec(int number)
        {
            if (number < 1)
                throw new ArgumentOutOfRangeException("Fibonacci number can't be less then 1");

            if (number > 46)
                throw new ArgumentOutOfRangeException("Fibonacci exceed maximum integer value");

            if (number == 1)
                return 1;

            if (number == 2)
                return 1;

            return CalculateRec(number - 1) + CalculateRec(number - 2);
        }

    }
}

