using Lection16Program2;
using Moq;

namespace Lection16Program2Tests;

[TestFixture]
public class CalculatorTests
{
    [Test]
    public void Add_ValidInput_ReturnsSum()
    {
        var calculatorServiceMock = new Mock<ICalculatorService>();

        calculatorServiceMock.Setup(x => x.Add(2, 3)).Returns(5);
        
        var calculator = new Calculator(calculatorServiceMock.Object);
        
        int result = calculator.Add(2, 3);

        Assert.That(result, Is.EqualTo(5));
    }


    [Test]
    public void Sub_ValidInput_ReturnsSub()
    {
        
        var calculatorServiceMock = new Mock<ICalculatorService>();

        calculatorServiceMock.Setup(x => x.Subtract(22, 33)).Returns(-9);
        
        var calculator = new Calculator(calculatorServiceMock.Object);
        
        int result = calculator.Subtract(22, 33);

        

        Assert.That(result, Is.EqualTo(-9));
    }

    [Test]
    public void AssertThatDoubleTest()
    {
        double actual = 0.1;
        double expected = 0.11;

        Assert.That(actual, Is.EqualTo(expected).Within(0.001));

    }



    [Test]
    public void AssertWarnTest()
    {
        Assert.Warn("Я ничего не делаю.");
    }


}