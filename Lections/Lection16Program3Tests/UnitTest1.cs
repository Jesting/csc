using Xunit;

public class FactorialCalculatorTests
{
    [Fact]
    public void CalculateFactorial_WhenCalledWith5_Returns120()
    {
        // Arrange (Подготовка данных)
        int number = 5;

        // Act (Действие)
        int result = FactorialCalculator.CalculateFactorial(number);

        // Assert (Проверка утверждений)
        Assert.Equal(120, result);
    }


    [Fact]
    public void CalculateFactorial_Fist10()
    {
        Assert.Equal(0,FactorialCalculator.CalculateFactorial(0));
        Assert.Equal(1, FactorialCalculator.CalculateFactorial(1));
        Assert.Equal(2, FactorialCalculator.CalculateFactorial(2));
        Assert.Equal(6, FactorialCalculator.CalculateFactorial(3));
        Assert.Equal(24, FactorialCalculator.CalculateFactorial(4));
        Assert.Equal(120, FactorialCalculator.CalculateFactorial(5));
        Assert.Equal(720, FactorialCalculator.CalculateFactorial(6));
        Assert.Equal(5040, FactorialCalculator.CalculateFactorial(7));
        Assert.Equal(40320, FactorialCalculator.CalculateFactorial(8));
        Assert.Equal(362880, FactorialCalculator.CalculateFactorial(9));
        Assert.Equal(3628800, FactorialCalculator.CalculateFactorial(10));
    }


    [Fact]
    public void CalculateFactorial_Negative()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => FactorialCalculator.CalculateFactorial(-1));
    }


    [Fact]
    public void CalculateFactorial_MacInput()
    {
        int last = FactorialCalculator.CalculateFactorial(0);
        for (int i = 1; i < int.MaxValue; i++)
        {
            int current = FactorialCalculator.CalculateFactorial(i);

            if (current < last)
            {
                Assert.Fail($"Max factorial is {last} for n = {i - 1}");
            }
            else
            {
                last = current;
            }
        }
    }

    [Fact]
    public void CalculateFactorial_14()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => FactorialCalculator.CalculateFactorial(14));
    }

}