using NUnit.Framework;

public class CalculatorExample
{
    public int Add(int a, int b)
    {
        return a + b;
    }
}

[TestFixture]
public class CalculatorTests
{
    private CalculatorExample _calculator;

    [SetUp]
    public void SetUp()
    {
        _calculator = new CalculatorExample();
    }

    [Test]
    public void Add_WhenCalled_ReturnsSum()
    {
        int result = _calculator.Add(2, 3);

        
        Assert.AreEqual(5, result);
    }

    [Test]
    public void Add_WhenCalledWithNegativeNumbers_ReturnsCorrectResult()
    {
        int result = _calculator.Add(-2, -3);
     
        Assert.AreEqual(-5, result);
    }
}