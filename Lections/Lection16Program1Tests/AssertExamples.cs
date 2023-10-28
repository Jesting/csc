using System;
namespace Lection16Program1Tests
{
	[TestClass]
	public class AssertExamples
	{

		[TestMethod]
		public void AssertAreEqualTestDouble()
		{
            double expected = 0.1;
            double actual = 0.1000001;
            double tolerance = 0.0001; 

            Assert.AreEqual(expected, actual, tolerance);
        }

        [TestMethod]
        public void AssertAreEqualTestObject()
        {
            var expected = new object();
            var actual = new object();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestStringComparisonCaseSensitive()
        {
            string expected = "Hello";
            string actual = "hello";

            Assert.AreEqual(expected, actual, false);
        }

        [TestMethod]
        public void TestStringComparisonIgnoreCase()
        {
            string expected = "Hello";
            string actual = "hello";
            
            Assert.AreEqual(expected, actual, true);
        }

        [TestMethod]
        public void TestIntEquality()
        {
            int expected = 42;
            int actual = 42;

            Assert.AreEqual<int>(expected, actual);
        }

       
        record class SomeRecordClass
        {
            public int Field;
        }

        [TestMethod]
        public void AssertAreEqualRecordClass()
        {
            var expected = new SomeRecordClass { Field = 42 };
            var actual = new SomeRecordClass { Field = 42 };

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AssertAreSameRecordClass()
        {
            var expected = new SomeRecordClass { Field = 42 };
            var actual = new SomeRecordClass { Field = 42 };

            Assert.AreSame(expected, actual);
        }

        class SomeClass
        {
            public int Field;
        }
       
        [TestMethod]
        public void AssertAreEqualClass()
        {
            var expected = new SomeClass { Field = 42 };
            var actual = new SomeClass { Field = 42 };

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AssertAreSameClass()
        {
            var expected = new SomeClass { Field = 42 };
            var actual = new SomeClass { Field = 42 };

            Assert.AreSame(expected, actual);
        }

        [TestMethod]
        public void FailTest()
        {
            Assert.Fail("Ошибка в тесте!");
        }

        [TestMethod]
        public void TestIsTrue()
        {
            int x = 5;
            int y = 3;

            bool result = x > y;
         
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestIsFalse()
        {
            int x = 5;
            int y = 3;

            bool result = x > y;

            Assert.IsFalse(result);
        }


        [TestMethod]
        public void TestIsInstanceOfType()
        {
            object myObject = new SomeClass();
            
            Assert.IsInstanceOfType(myObject, typeof(SomeClass));
        }

        [TestMethod]
        public void TestIsInstanceOfTypeFail()
        {
            object myObject = new SomeClass();

            Assert.IsInstanceOfType(myObject, typeof(SomeRecordClass));
        }

        [TestMethod]
        public void TestIsNull()
        {
            string nullString = null;

            Assert.IsNull(nullString);
        }


        [TestMethod]
        public void TestThrowsException()
        {
            Action action = () => { throw new ArgumentException(); };
         
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public void TestThrowsExceptionFail()
        {
            Action action = () => { throw new NullReferenceException(); };

            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        public async Task TestThrowsExceptionAsync()
        {
            Func<Task> asyncFunc = async () => { await Task.Delay(10); throw new InvalidOperationException(); };
           
            await Assert.ThrowsExceptionAsync<InvalidOperationException>(asyncFunc);
        }

        [TestMethod]
        public async Task TestThrowsExceptionAsyncFail()
        {
            Func<Task> asyncFunc = async () => { await Task.Delay(10); };

            await Assert.ThrowsExceptionAsync<InvalidOperationException>(asyncFunc);
        }

        [TestMethod]
        public async Task TestThrowsExceptionAsyncFailWrongException()
        {
            Func<Task> asyncFunc = async () => { await Task.Delay(10); throw new InvalidOperationException(); };

            await Assert.ThrowsExceptionAsync<NullReferenceException>(asyncFunc);
        }
    }
}

