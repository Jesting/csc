using System;
using Lection16Program1;

namespace Lection16Program1Tests
{
    [TestClass]
    public class SortTests
	{
        [TestMethod]
        public void TestNull()
        {
            var sort = new BubbleSort();
            sort.Sort(null);
        }

        [TestMethod]
        public void TestEmpty()
        {
            var sort = new BubbleSort();
            sort.Sort(new int[] { });
        }

        [TestMethod]
        public void TestSort()
        {
            var arr = new int[] { 9, 1, 2, 9, 0, 1, -1, -1, 8, 2, 4, 5, 6, 7, 8, 4, 43, 6, 7, 8 };

            var sort = new BubbleSort();
            sort.Sort(arr);

            for (int i = 1; i < arr.Length; i++)
            {
                Assert.IsTrue(arr[i] >= arr[i - 1]);
            }
        }
    }
}

