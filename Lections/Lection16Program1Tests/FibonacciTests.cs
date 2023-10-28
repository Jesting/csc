using Lection16Program1;

namespace Lection16Program1Tests;

[TestClass]
public class FibonacciTests
{

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException), "Method should throw ArgumentOutOfRangeException")]
    public void TestNonValidValueNegative()
    {
        new Fibonacci().Calculate(-1);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException), "Method should throw ArgumentOutOfRangeException")]
    public void TestNonValidValueMax()
    {
        new Fibonacci().Calculate(47);
    }

    [TestMethod]
    public void TestRest()
    {
        var fib = new Fibonacci();

        Assert.AreEqual(1, fib.Calculate(1));
        Assert.AreEqual(1, fib.Calculate(2));
        Assert.AreEqual(2, fib.Calculate(3));
        Assert.AreEqual(3, fib.Calculate(4));
        Assert.AreEqual(5, fib.Calculate(5));
    }

    


    [TestMethod]
    public void TestRecursion()
    {
        var fib = new Fibonacci();


        for (int i = 1; i <= 46; i++)
        {
            Assert.AreEqual(fib.Calculate(i), fib.CalculateRec(i));
        }

        
    }



}
